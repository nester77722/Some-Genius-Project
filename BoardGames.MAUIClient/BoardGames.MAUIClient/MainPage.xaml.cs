using BoardGames.MAUIClient.Views;
using Serilog;
/* Unmerged change from project 'BoardGames.MAUIClient (net6.0-windows10.0.19041.0)'
Before:
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
After:
using System.Net;
using System.Net.Sockets;
*/

/* Unmerged change from project 'BoardGames.MAUIClient (net6.0-maccatalyst)'
Before:
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
After:
using System.Net;
using System.Net.Sockets;
*/

/* Unmerged change from project 'BoardGames.MAUIClient (net6.0-ios)'
Before:
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
After:
using System.Net;
using System.Net.Sockets;
*/


namespace BoardGames.MAUIClient;

public partial class MainPage : ContentPage
{
	public MainPage(GenresListPage genresListPage)
	{

        InitializeComponent();
    }
}

