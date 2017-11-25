using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace F1Telemetry.Models
{
    public class CarData
    {
        public Driver Driver { get; set; }
        public Team Team { get; set; }
        public List<CarLiveData> CarLiveData { get; set; }
        public List<Laptime> Laptimes { get; set; }
    }
}
