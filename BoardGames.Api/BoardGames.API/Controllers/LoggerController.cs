using BoardGames.API.Models.LogEvents;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        [HttpPost]
        public void Test(object @object)
        {

        }
        //public void PostRawBufferManual(LogEvent[] logs)
        //{
        //    foreach (var log in logs)
        //    {
        //        Log.ForContext("Device", log.DeviceInfo.Device.ToString()).Write(log.Level, log.MessageTemplate);
        //    }
        //}
    }
}
