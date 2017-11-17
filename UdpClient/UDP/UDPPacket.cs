using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryHandling.UDP
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UDPPacket
    {
        public float Time;

        public float LapTime;

        public float LapDistance;

        public float TotalDistance;

        /// <summary>
        /// World space position
        /// </summary>
        public float X;

        /// <summary>
        /// World space position
        /// </summary>
        public float Y;

        /// <summary>
        /// World space position
        /// </summary>
        public float Z;

        /// <summary>
        /// Speed of car in MPH
        /// </summary>
        public float Speed;

        /// <summary>
        /// Velocity in world space
        /// </summary>
        public float Xv;

        /// <summary>
        /// Velocity in world space
        /// </summary>
        public float Yv;

        /// <summary>
        /// Velocity in world space
        /// </summary>
        public float Zv;

        /// <summary>
        /// World space right direction
        /// </summary>
        public float Xr;

        /// <summary>
        /// World space right direction
        /// </summary>
        public float Yr;

        /// <summary>
        /// World space right direction
        /// </summary>
        public float Zr;

        /// <summary>
        /// World space forward direction
        /// </summary>
        public float Xd;

        /// <summary>
        /// World space forward direction
        /// </summary>
        public float Yd;

        /// <summary>
        /// World space forward direction
        /// </summary>
        public float Zd;

        /// <summary>
        /// Note: All wheel arrays have the order:
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspPos;

        /// <summary>
        /// RL, RR, FL, FR
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspVel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelSpeed;

        public float Throttle;

        public float Steer;

        public float Brake;

        public float Clutch;

        public float Gear;

        public float GforceLat;

        public float GforceLon;

        public float Lap;

        public float EngineRate;

        /// <summary>
        /// SLI Pro support
        /// </summary>
        public float SliProNativeSupport;

        /// <summary>
        /// car race position
        /// </summary>
        public float CarPosition;

        /// <summary>
        /// kers energy left
        /// </summary>
        public float KersLevel;

        /// <summary>
        /// kers maximum energy
        /// </summary>
        public float KersMaxLevel;

        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public float Drs;

        /// <summary>
        /// 0 (off) - 2 (high)
        /// </summary>
        public float TractionControl;

        /// <summary>
        /// 0 (off) - 1 (on)
        /// </summary>
        public float AntiLockBrakes;

        /// <summary>
        /// current fuel mass
        /// </summary>
        public float FuelInTank;

        /// <summary>
        /// fuel capacity
        /// </summary>
        public float FuelCapacity;

        /// <summary>
        /// 0 = none, 1 = pitting, 2 = in pit area
        /// </summary>
        public float InPits;

        /// <summary>
        /// 0 = sector1, 1 = sector2, 2 = sector3
        /// </summary>
        public float Sector;

        /// <summary>
        /// time of sector1 (or 0)
        /// </summary>
        public float Sector1Time;

        /// <summary>
        /// time of sector2 (or 0)
        /// </summary>
        public float Sector2Time;

        /// <summary>
        /// brakes temperature (centigrade)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] BrakesTemp;

        /// <summary>
        /// tyres pressure PSI
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyresPressure;

        /// <summary>
        /// team ID
        /// </summary>
        public float TeamInfo;

        /// <summary>
        /// total number of laps in this race
        /// </summary>
        public float TotalLaps;

        /// <summary>
        /// track size meters
        /// </summary>
        public float TrackSize;

        /// <summary>
        /// last lap time
        /// </summary>
        public float LastLapTime;

        /// <summary>
        /// cars max RPM, at which point the rev limiter will kick in
        /// </summary>
        public float MaxRpm;

        /// <summary>
        /// cars idle RPM
        /// </summary>
        public float IdleRpm;

        /// <summary>
        /// maximum number of gears
        /// </summary>
        public float MaxGears;

        /// <summary>
        /// 0 = unknown, 1 = practice, 2 = qualifying, 3 = race
        /// </summary>
        public float SessionType;

        /// <summary>
        /// 0 = not allowed, 1 = allowed, -1 = invalid / unknown
        /// </summary>
        public float DrsAllowed;

        /// <summary>
        /// -1 for unknown, 0-21 for tracks
        /// </summary>
        public float TrackNumber;

        /// <summary>
        /// -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        /// </summary>
        public float VehicleFIAFlags;

        /// <summary>
        /// era, 2017 (modern) or 1980 (classic)
        /// </summary>
        public float Era;

        /// <summary>
        /// engine temperature (centigrade)
        /// </summary>
        public float EngineTemperature;

        /// <summary>
        /// vertical g-force component
        /// </summary>
        public float GforceVert;

        /// <summary>
        /// angular velocity x-component
        /// </summary>
        public float AngVelX;

        /// <summary>
        /// angular velocity y-component
        /// </summary>
        public float AngVelY;

        /// <summary>
        /// angular velocity z-component
        /// </summary>
        public float AngVelZ;

        /// <summary>
        /// tyres temperature (centigrade)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] TyresTemperature;

        /// <summary>
        /// tyre wear percentage
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] TyresWear;

        /// <summary>
        /// compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet
        /// </summary>
        public byte TyreCompound;

        /// <summary>
        /// front brake bias (percentage)
        /// </summary>
        public byte FrontBrakeBias;

        /// <summary>
        /// fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        /// </summary>
        public byte FuelMix;

        /// <summary>
        /// current lap invalid - 0 = valid, 1 = invalid
        /// </summary>
        public byte CurrentLapInvalid;

        /// <summary>
        /// tyre damage (percentage)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] TyresDamage;

        /// <summary>
        /// front left wing damage (percentage)
        /// </summary>
        public byte FrontLeftWingDamage;

        /// <summary>
        /// front right wing damage (percentage)
        /// </summary>
        public byte FrontRightWingDamage;

        /// <summary>
        /// rear wing damage (percentage)
        /// </summary>
        public byte RearWingDamage;

        /// <summary>
        /// engine damage (percentage)
        /// </summary>
        public byte EngineDamage;

        /// <summary>
        /// gear box damage (percentage)
        /// </summary>
        public byte GearBoxDamage;

        /// <summary>
        /// exhaust damage (percentage)
        /// </summary>
        public byte ExhaustDamage;

        /// <summary>
        /// pit limiter status – 0 = off, 1 = on
        /// </summary>
        public byte PitLimiterStatus;

        /// <summary>
        /// pit speed limit in mph
        /// </summary>
        public byte PitSpeedLimit;

        /// <summary>
        /// time left in session in seconds
        /// </summary>
        public float SessionTimeLeft;

        /// <summary>
        /// rev lights indicator (percentage)
        /// </summary>
        public byte RevLightsPercent;

        /// <summary>
        /// whether the player is spectating
        /// </summary>
        public byte IsSpectating;

        /// <summary>
        /// index of the car being spectated
        /// </summary>
        public byte SpectatorCarIndex;
        
        /// <summary>
        /// number of cars in data
        /// </summary>
        public byte NumCars;

        /// <summary>
        /// index of player's car in the array
        /// </summary>
        public byte PlayerCarIndex;

        /// <summary>
        /// data for all cars on track
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CarUDPData[] CarData;

        public float Yaw;

        public float Pitch;

        public float Roll;

        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float XLocalVelocity;

        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float YLocalVelocity;

        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float ZLocalVelocity;

        /// <summary>
        /// RL, RR, FL, FR
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspAcceleration;

        /// <summary>
        /// angular acceleration x-component
        /// </summary>
        public float AngAccX;

        /// <summary>
        /// angular acceleration y-component
        /// </summary>
        public float AngAccY;

        /// <summary>
        /// angular acceleration z-component
        /// </summary>
        public float AngAccZ;
    }
}
