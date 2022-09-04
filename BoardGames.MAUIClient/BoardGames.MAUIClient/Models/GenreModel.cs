using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models
{
    public partial class GenreModel : ObservableObject
    {
        public GenreModel()
        {
            _id = string.Empty;
            _name = string.Empty;
        }

        public GenreModel(string id, string name)
        {
            _id = id;
            _name = name;
        }
        [ObservableProperty]
        private string? _id;
        [ObservableProperty]
        private string? _name;
        
    }
}
