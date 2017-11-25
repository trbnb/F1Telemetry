using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{
    public class CarLiveData
    {
        public TimeSpan Timestamp { get; set; }

        public XYZ WorldPosition { get; set; }
        
        public TimeSpan CurrentLapTime { get; set; }
        public TimeSpan? BestLapTime { get; set; }
        public float LapDistance { get; set; }

        public int CarPosition { get; set; }
        public int CurrentLap { get; set; }
        public TyreCompound TyreCompound { get; set; }
        public PitStatus PitStatus { get; set; }
        public Sector Sector { get; set; }
        public bool IsCurrentLapInvalid { get; set; }
        public int Penalties { get; set; }
    }
}
