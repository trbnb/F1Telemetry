using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{
    public class FuelInfo
    {
        public float FuelInTank { get; set; }
        public float FuelCapacity { get; set; }
        public FuelMix FuelMix { get; set; }
    }
}
