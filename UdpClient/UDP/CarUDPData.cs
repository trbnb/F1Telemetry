using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryHandling.UDP
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarUDPData
    {
        /// <summary>
        /// world co-ordinates of vehicle
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] WorldPosition;

        public float LastLapTime;

        public float CurrentLapTime;

        public float BestLapTime;

        public float Sector1Time;

        public float Sector2Time;

        public float LapDistance;

        public byte DriverId;

        public byte TeamId;

        /// <summary>
        /// track positions of vehicle
        /// </summary>
        public byte CarPosition;

        public byte CurrentLapNum;

        /// <summary>
        /// compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet
        /// </summary>
        public byte TyreCompound;

        /// <summary>
        /// 0 = none, 1 = pitting, 2 = in pit area
        /// </summary>
        public byte InPits;

        /// <summary>
        /// 0 = sector1, 1 = sector2, 2 = sector3
        /// </summary>
        public byte Sector;

        /// <summary>
        /// current lap invalid - 0 = valid, 1 = invalid
        /// </summary>
        public byte CurrentLapInvalid;

        /// <summary>
        /// NEW: accumulated time penalties in seconds to be added
        /// </summary>
        public byte Penalties;

    }
}
