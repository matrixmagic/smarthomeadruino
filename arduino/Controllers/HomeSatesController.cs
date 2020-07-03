using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arduino.DTO;
using arduino.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace arduino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeSatesController : ControllerBase
    {



        private IMemoryCache _cache;

        public HomeSatesController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;


        }
        [HttpGet("GetSecuritySate")]
        public bool GetSecuritySate()
        {
          var  SecuritySate = _cache.Get<bool?>(HomeStates.SecuritySate);

            return ( bool) SecuritySate;

        }

        [HttpGet("GetLedSate")]
        public bool GetLedSate()
        {
            var LedState = _cache.Get<bool?>(HomeStates.LedState);

            return (bool)LedState;

        }



        [HttpGet("GetAllState")]
        public AllState GetAllState()
        {
            AllState valuess = new AllState();
            valuess.LedState = (bool)_cache.Get<bool?>(HomeStates.LedState);

            return valuess;

        }


    }

}