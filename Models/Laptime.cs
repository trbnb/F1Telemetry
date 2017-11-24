using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Laptime
    {
        public uint Number { get; set; }
        public TimeSpan Sector1 { get; set; }
        public TimeSpan Sector2 { get; set; }
        public TimeSpan Total { get; set; }

        public TimeSpan Sector3 => Total - (Sector1 + Sector2);
    }
}
