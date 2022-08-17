﻿using BoardGames.API.Controllers;
using System.Text.Json.Serialization;

namespace BoardGames.API.Models.LogEvents
{
    public class LogEvent
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string MessageTemplate { get; set; }
        public string RenderedMessage { get; set; }
        [JsonPropertyName("Properties")]
        public DeviceInfo DeviceInfo { get; set; }
    }
}
