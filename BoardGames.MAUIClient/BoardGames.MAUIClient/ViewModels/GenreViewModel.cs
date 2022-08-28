using BoardGames.MAUIClient.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BoardGames.MAUIClient.ViewModels
{
    public class GenreViewModel : ObservableObject
    {
        private GenresListViewModel _lvm;

        private readonly GenreModel _genre;

        public GenreViewModel()
        {
            _genre = new GenreModel();
        }

        public GenreViewModel(GenreModel genre)
        {
            _genre = genre;
        }

        public GenresListViewModel ListViewModel
        {
            get => _lvm;
            set => SetProperty(ref _lvm, value, "ListViewModel");

            //set
            //{
            //    if (lvm != value)
            //    {
            //        lvm = value;
            //        OnPropertyChanged("ListViewModel");
            //    }
            //}
        }

        public string Name
        {
            get => _genre.Name;
            set => SetProperty(_genre.Name, value, _genre, (g, n) => g.Name = n, "Name");
        }

        public string Id
        {
            get => _genre.Id;
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Name.Trim());
            }
        }
    }
}