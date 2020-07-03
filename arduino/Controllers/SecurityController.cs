using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using arduino.DTO;
using arduino.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace arduino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private IMemoryCache _cache;

        public SecurityController(
            IConfiguration iConfig,
            IMemoryCache memoryCache)
        {
            _configuration = iConfig;
            _cache = memoryCache;
        }

        [HttpPost]
        public bool ConfirmSecurityCode(Security security)
        {

            var SecuritySate = _cache.Get<bool?>(HomeStates.SecuritySate);

           
            string storedCode = _configuration.GetSection("Security").GetSection("code").Value;


            if (storedCode == security.code) {
                //change state

                using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                {
                    writer.WriteLine("code is true and the state is chagned  :  " + DateTime.Now.ToString());
                }

                _cache.Set(HomeStates.SecuritySate, !SecuritySate);

                return true;

            
            }
            return false;
        }

    }
}