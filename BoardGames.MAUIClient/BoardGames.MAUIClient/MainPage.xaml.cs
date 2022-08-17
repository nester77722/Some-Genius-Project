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
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		Log.Error("Test");

	}
}

