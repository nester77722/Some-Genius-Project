using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models
{
    public partial class GameModel : ObservableValidator
    {
        [ObservableProperty]
        private string? _id;
        [ObservableProperty]
        private string? _name;
        [ObservableProperty]
        private GenreModel? _genre;
        [ObservableProperty]
        private IEnumerable<MechanicModel>? _mechanics;
    }
}
