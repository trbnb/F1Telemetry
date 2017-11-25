using System;
using System.Collections.Generic;
using System.Text;
using F1Telemetry.Models;

namespace Models
{
    public class SessionData
    {
        public float TotalDistance { get; set; }
        public int TotalLaps { get; set; }
        public float TrackSize { get; set; }
        public CarInfo CarInfo { get; set; }
        public SessionType SessionType { get; set; }
        public int TrackNumber { get; set; }
        public Era Era { get; set; }
        public uint PitSpeedLimit { get; set; }
        public CarData[] CarData { get; set; }

        public List<SessionLiveData> SessionLiveData { get; set; }
        public uint PlayerCarIndex { get; set; }

        public bool IsSpectating { get; set; }
        public uint SpectatorCarIndex { get; set; }
    }
}
