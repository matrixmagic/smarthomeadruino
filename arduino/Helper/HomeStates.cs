using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arduino.Helper
{
    public class HomeStates
    {
        public static String  SecuritySate { get { return "_security"; } }
        public static String LedState { get { return "_Ledstat"; } }

    }
}
