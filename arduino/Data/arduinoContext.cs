using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using arduino.Models;

namespace arduino.Data
{
    public class arduinoContext : DbContext
    {
        public arduinoContext (DbContextOptions<arduinoContext> options)
            : base(options)
        {
        }

        public DbSet<arduino.Models.Consuming> Consuming { get; set; }

        public DbSet<arduino.Models.Temprature> Temprature { get; set; }
    }
}
