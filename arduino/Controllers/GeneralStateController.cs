using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using arduino.DTO;
using arduino.Helper;
using arduino.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace arduino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralStateController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly IHubContext<EventHub> _SingalRcontext;
        private IMemoryCache _cache;

        public GeneralStateController(
            IConfiguration iConfig, IHubContext<EventHub> singalrcontext,
            IMemoryCache memoryCache)
        {
            _configuration = iConfig;
            _cache = memoryCache;

            _SingalRcontext = singalrcontext;
        }

        [HttpPost("ChangLedState")]
        public async Task<bool> ChangLedStateAsync()
        {

            var LedState = _cache.Get<bool?>(HomeStates.LedState);



            try
            {

                _cache.Set(HomeStates.LedState, !LedState);

                await _SingalRcontext.Clients.All.SendAsync("thereIsChange");
                ArduinoEventSender.sentEvent("1");
                using (StreamWriter writer = System.IO.File.AppendText("okkkkk.txt"))
                {
                    writer.WriteLine("okkkkkk  :  "+ " " + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = System.IO.File.AppendText("exeeeeee.txt"))
                {
                    writer.WriteLine("exxx  :  " + ex.ToString() + " " + DateTime.Now.ToString());
                    ArduinoEventSender.StartArduinoEventSender();
                }


            }

          

            return (bool)!LedState;
    }

        [HttpPost("test")]
        public async Task<bool> testAsync()
        {
         await _SingalRcontext.Clients.All.SendAsync("thereIsChange");
   




            return true;
        }

    }
}