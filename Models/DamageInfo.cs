using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{
    public class DamageInfo
    {
        public WheelInfo<uint> Tyres { get; set; }
        public uint FrontwingLeft { get; set; }
        public uint FrontwingRight { get; set; }
        public uint Rearwing { get; set; }
        public uint Engine { get; set; }
        public uint Gearbox { get; set; }
        public uint Exhaust { get; set; }
    }
}
