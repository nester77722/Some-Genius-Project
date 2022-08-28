using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BoardGames.MAUIClient.ViewModels
{
    public partial class GenresListViewModel : ObservableObject
    {
        private GenreViewModel _selectedGenre;
        private readonly IGenreService _genreService;
        public ObservableCollection<GenreViewModel> Genres { get; set; }

        //public ICommand CreateGenreCommand { protected set; get; }
        //public ICommand DeleteGenreCommand { protected set; get; }
        //public ICommand SaveGenreCommand { protected set; get; }
        //public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public GenresListViewModel(IGenreService genreService)
        {
            Genres = new ObservableCollection<GenreViewModel>();
            //CreateGenreCommand = new Command(CreateGenre);
            //DeleteGenreCommand = new Command(DeleteGenre);
            //SaveGenreCommand = new Command(SaveGenre);
            //BackCommand = new Command(Back);
            _genreService = genreService;

            GetGenres();
        }

        public GenreViewModel SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                var tempGenre = value;
                _selectedGenre = null;
                OnPropertyChanged("SelectedGenre");

                Navigation.PushAsync(new GenrePage(tempGenre));
            }
        }

        #region Commands

        [RelayCommand]
        private void CreateGenre()
        {
            Navigation.PushAsync(new GenrePage(new GenreViewModel() { ListViewModel = this }));
        }
        [RelayCommand]
        private void Back()
        {
            Navigation.PopAsync();
        }
        [RelayCommand]
        private async void SaveGenre(object friendObject)
        {
            GenreViewModel genre = friendObject as GenreViewModel;
            if (genre != null && genre.IsValid)
            {
                if (string.IsNullOrEmpty(genre.Id))
                {
                    await _genreService.CreateGenre(new GenreModel { Name = genre.Name });
                }
            }

            Back();
            GetGenres();
        }
        [RelayCommand]
        private async void GetGenres()
        {
            var genres = await _genreService.GetGenres();

            var genreViewModels = genres.Select(x => new GenreViewModel(new GenreModel(x.Id, x.Name)) {ListViewModel = this });

            Genres.Clear();

            foreach(var item in genreViewModels)
            {
                Genres.Add(item);
            }
        }
        [RelayCommand]
        private async void DeleteGenre(object genreObject)
        {
            GenreViewModel genre = genreObject as GenreViewModel;
            if (genre != null)
            {
                await _genreService.DeleteGenre(new GenreModel(genre.Id, genre.Name));
            }
            Back();
            GetGenres();
        }
        #endregion
    }
}
