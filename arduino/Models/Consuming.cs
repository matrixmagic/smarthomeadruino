using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arduino.Models
{
    public class Consuming
    {


        public int Id { get; set; }
        public int LightLevel { get; set; }
        public double watt { get; set; }
        public DateTime? date { get; set; }
    }
}
