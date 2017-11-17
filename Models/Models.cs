using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{  
    public class SectorTimes
    {
        public float One { get; set; }
        public float Two { get; set; }
    }
    
    public class SessionLiveData
    {
        public TimeSpan Time { get; set; }
        public TimeSpan LapTime { get; set; }
        public float LapDistance { get; set; }
        public XYZ WorldSpacePosition { get; set; }
        public float Speed { get; set; }
        public XYZ Velocity { get; set; }
        public XYZ WorldSpaceRightDirection { get; set; }
        public XYZ WorldSpaceForwardDirection { get; set; }
        public WheelInfo<float> SuspensionPosition { get; set; }
        public WheelInfo<float> SuspensionVelocity { get; set; }
        public WheelInfo<float> WheelSpeed { get; set; }
        public Pedals Pedals { get; set; }
        public uint Gear { get; set; }
        public GForce GForce { get; set; }
        public uint Lap { get; set; }
        public float EngineRate { get; set; }
        public int CarPosition { get; set; }
        public KersInfo KersInfo { get; set; }
        public bool IsDrsOn { get; set; }
        public TractionControl TractionControl { get; set; }
        public bool IsAntiLockBrakesOn { get; set; }
        public FuelInfo FuelInfo { get; set; }
        public PitStatus PitStatus { get; set; }
        public Sector Sector { get; set; }
        public SectorTimes SectorTimes { get; set; }
        public WheelInfo<float> BrakesTemperatures { get; set; }
        public WheelInfo<float> TyrePressures { get; set; }
        public TimeSpan LastLapTime { get; set; }
        public DrsAllowed DrsAllowed { get; set; }
        public FiaFlag Flag { get; set; }
        public float EngineTemperature { get; set; }
        public XYZ AngularVelocity { get; set; }
        public WheelInfo<uint> TyreTemparatures { get; set; }
        public WheelInfo<uint> TyreWear { get; set; }
        public TyreCompound TyreCompound { get; set; }
        public uint FrontBrakeBias { get; set; }
        public bool IsCurrentLapInvalid { get; set; }
        public DamageInfo DamageInfo { get; set; }
        public bool IsPitLimiterOn { get; set; }
        public TimeSpan SessionTimeLeft { get; set; }
        public uint RevLightsPercentage { get; set; }
        public CarLiveData[] CarLiveData { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public XYZ LocalVelocity { get; set; }
        public WheelInfo<float> SuspensionAcceleration { get; set; }
        public XYZ AngularAcceleration { get; set; }
    }

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
