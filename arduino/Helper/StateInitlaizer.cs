using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arduino.Helper
{
    public class StateInitlaizer
    {
        private IMemoryCache _cache;

        
        public StateInitlaizer(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            intializeSecuritySate();
            intializeLedSate();
        }
    private    void intializeSecuritySate()
        {
            var SecuritySate = _cache.Get<bool?>(HomeStates.SecuritySate);

            if (SecuritySate == null)
            {
                // Key not in cache, so get data.



                // Save data in cache.
                _cache.Set(HomeStates.SecuritySate, false);
            }



        }



        private void intializeLedSate()
        {
            var LedStat = _cache.Get<bool?>(HomeStates.LedState);

            if (LedStat == null)
            {
                // Key not in cache, so get data.



                // Save data in cache.
                _cache.Set(HomeStates.LedState, true);
            }



        }


    }
}
