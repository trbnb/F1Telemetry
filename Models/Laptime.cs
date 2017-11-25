using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Laptime
    {
        public Laptime(uint number)
        {
            Number = number;
        }

        public uint Number { get; set; }
        public TimeSpan? Sector1 { get; set; }
        public TimeSpan? Sector2 { get; set; }
        public TimeSpan? Total { get; set; }

        public TimeSpan? Sector3 => Total == null || Sector1 == null || Sector2 == null ? null : Total - (Sector1 + Sector2);

        public bool IsComplete => Total != null;
    }
}
