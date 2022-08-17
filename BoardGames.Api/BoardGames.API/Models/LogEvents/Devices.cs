using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BoardGames.API.Models.LogEvents
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Devices
    {
        iOS,
        WinUI,
        UWP,
        Tizen,
        tvOS,
        MacCatalyst,
        macOS,
        watchOS,
        Unknown,
        Android
    }
}
