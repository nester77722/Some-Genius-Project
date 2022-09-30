using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models
{
    public partial class GenreModel : ObservableValidator
    {
        [ObservableProperty]
        private string? _id;
        private string? _name;
        [ObservableProperty]
        private IEnumerable<GameModel>? _games;
        
        public GenreModel()
        {
            Id = string.Empty;
            Name = string.Empty;
            Games = new List<GameModel>();
        }

        public GenreModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        [Required]
        [MinLength(4, ErrorMessage = "Name should be longer than 4 character")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, true);
        }
    }
}
