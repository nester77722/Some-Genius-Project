using BoardGames.API.Models.LogEvents;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        [HttpPost]
        public void Test(dynamic log)
        {
            var test = log as LogEvent;
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
