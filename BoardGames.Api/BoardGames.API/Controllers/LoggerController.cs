using BoardGames.API.Models.LogEvents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json.Serialization;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {

        [HttpPost]
        public async Task PostRawBufferManual(LogEvent[] logs)
        {

        }
    }
}
