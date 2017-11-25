using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryHandling.UDP;
using F1Telemetry.Models;
using Models;
using UdpTestApp;
using Utils;

namespace BusinessLogic
{
    internal class SessionConverter
    {
        public SessionData Convert(SessionData sessionData, UDPPacket packet)
        {
            if (sessionData == null)
            {
                sessionData = InitSessionData();
                
                sessionData.TotalDistance = packet.TotalDistance;
                sessionData.TotalLaps = (int)packet.TotalLaps;
                sessionData.TrackSize = packet.TrackSize;
                sessionData.SessionType = (SessionType)packet.SessionType;
                sessionData.TrackNumber = (int)packet.TrackNumber;
                sessionData.Era = (Era)packet.SessionType;
                sessionData.PitSpeedLimit = packet.PitSpeedLimit;
                sessionData.PlayerCarIndex = packet.PlayerCarIndex;
                sessionData.IsSpectating = packet.IsSpectating == 1;
                sessionData.SpectatorCarIndex = packet.SpectatorCarIndex;

                sessionData.CarInfo = new CarInfo
                {
                    MaxRpm = packet.MaxRpm,
                    IdleRpm = packet.IdleRpm,
                    MaxGears = (int) packet.MaxGears
                };

                sessionData.CarData = packet.CarData.Select(e =>
                {
                    var driverMap = sessionData.Era == Era.MODERN ? Constants.DRIVER_IDS : Constants.CLASSIC_DRIVER_IDS;
                    var teamsMap = sessionData.Era == Era.MODERN ? Constants.TEAM_IDS : Constants.CLASSIC_TEAM_IDS;
                    var driverName = driverMap[e.DriverId];
                    var teamName = teamsMap[e.TeamId];

                    return new CarData
                    {
                        Driver = new Driver(e.DriverId, driverName),
                        Team = new Team(e.TeamId, teamName),
                        CarLiveData = new List<CarLiveData>()
                    };
                }).ToArray();
            }

            sessionData.CarData.Join(
                inner: packet.CarData,
                outerKeySelector: data => data.Driver.Id,
                innerKeySelector: data => data.DriverId,
                resultSelector: (data, udpData) => (data, udpData)
            ).ForEach(liveDataTuple =>
            {
                var (carData, carUdpData) = liveDataTuple;
                carData.CarLiveData.Add(ConvertCarLiveData(packet.Time, carUdpData));

                computeLapTimes(carUdpData.CurrentLapNum, carUdpData.Sector1Time, carUdpData.Sector2Time, carUdpData.LastLapTime, carData.Laptimes);
            });

            RemoveObsoleteData(packet.Time, sessionData);
            sessionData.SessionLiveData.Add(ConvertSessionLiveData(packet));

            return sessionData;
        }

        private void computeLapTimes(uint lapNumber, float sector1, float sector2, float lastLap, IList<Laptime> laptimes)
        {
            var laptime = laptimes.FirstOrDefault(lapTime => lapTime.Number == lapNumber);

            if (laptime == null)
            {
                laptime = new Laptime(lapNumber);
                laptimes.Add(laptime);
            }

            laptime.Sector1 = sector1.ToNullableTimeSpan();
            laptime.Sector2 = sector2.ToNullableTimeSpan();

            if (lapNumber > 1 && lastLap != 0)
            {
                var previousLapNumber = lapNumber - 1;
                var previousLap = laptimes.FirstOrDefault(e => e.Number == previousLapNumber);

                if (previousLap == null)
                {
                    previousLap = new Laptime(previousLapNumber);
                    laptimes.Add(previousLap);
                }

                previousLap.Total = lastLap.ToNullableTimeSpan();
            }
        }

        private void RemoveObsoleteData(float oldestTimestamp, SessionData data)
        {
            data.SessionLiveData.RemoveOldestItems(oldestTimestamp, liveData => liveData.Time.TotalSeconds);
            data.CarData.ForEach(carData => carData.CarLiveData.RemoveOldestItems(oldestTimestamp, liveData => liveData.Timestamp.TotalSeconds));
        }

        private CarLiveData ConvertCarLiveData(float timestamp, CarUDPData carUdpData)
        {
            return new CarLiveData
            {
                Timestamp = timestamp.ToTimeSpan(),
                WorldPosition = carUdpData.WorldPosition.ToXYZ(),
                CurrentLapTime = carUdpData.CurrentLapTime.ToTimeSpan(),
                BestLapTime = carUdpData.BestLapTime.ToNullableTimeSpan(),
                LapDistance = carUdpData.LapDistance,
                CarPosition = carUdpData.CarPosition,
                CurrentLap = carUdpData.CurrentLapNum,
                TyreCompound = (TyreCompound) carUdpData.TyreCompound,
                PitStatus = (PitStatus) carUdpData.InPits,
                Sector = (Sector) carUdpData.Sector,
                IsCurrentLapInvalid = carUdpData.CurrentLapInvalid == 1,
                Penalties = carUdpData.Penalties
            };
        }

        private SessionLiveData ConvertSessionLiveData(UDPPacket packet)
        {
            return new SessionLiveData
            {
                Time = packet.Time.ToTimeSpan(),
                LapTime = packet.LapTime.ToTimeSpan(),
                LapDistance = packet.LapDistance,
                WorldSpacePosition = new XYZ(packet.X, packet.Y, packet.Z),
                Speed = packet.Speed,
                Velocity = new XYZ(packet.Xv, packet.Yv, packet.Zv),
                WorldSpaceRightDirection = new XYZ(packet.Xr, packet.Yr, packet.Zr),
                WorldSpaceForwardDirection = new XYZ(packet.Xd, packet.Yd, packet.Zd),
                SuspensionPosition = packet.SuspPos.ParseWheelInfo(),
                SuspensionVelocity = packet.SuspVel.ParseWheelInfo(),
                WheelSpeed = packet.WheelSpeed.ParseWheelInfo(),
                Pedals = new Pedals
                {
                    Brake = packet.Brake,
                    Clutch = packet.Clutch,
                    Steer = packet.Steer,
                    Throttle = packet.Throttle
                },
                Gear = (uint) packet.Gear,
                GForce = new GForce(packet.GforceLat, packet.GforceLon, packet.GforceVert),
                Lap = (uint) packet.Lap,
                EngineRate = packet.EngineRate,
                CarPosition = (int) packet.CarPosition,
                KersInfo = new KersInfo
                {
                    KersLevel = packet.KersLevel,
                    KersMaxLevel = packet.KersMaxLevel
                },
                IsDrsOn = packet.Drs == 1,
                TractionControl = (TractionControl) packet.TractionControl,
                IsAntiLockBrakesOn = packet.AntiLockBrakes == 1,
                FuelInfo = new FuelInfo
                {
                    FuelCapacity = packet.FuelCapacity,
                    FuelInTank = packet.FuelInTank,
                    FuelMix = (FuelMix) packet.FuelMix
                },
                PitStatus = (PitStatus) packet.InPits,
                Sector = (Sector) packet.Sector,
                BrakesTemperatures = packet.BrakesTemp.ParseWheelInfo(),
                TyrePressures = packet.TyresPressure.ParseWheelInfo(),
                LastLapTime = packet.LastLapTime.ToTimeSpan(),
                DrsAllowed = (DrsAllowed) packet.DrsAllowed,
                Flag = (FiaFlag) packet.VehicleFIAFlags,
                EngineTemperature = packet.EngineTemperature,
                AngularVelocity = new XYZ(packet.AngVelX, packet.AngVelY, packet.AngVelZ),
                TyreTemparatures = packet.TyresTemperature.Cast<uint>().ToArray().ParseWheelInfo(),
                TyreWear = packet.TyresWear.Cast<uint>().ToArray().ParseWheelInfo(),
                TyreCompound = (TyreCompound) packet.TyreCompound,
                FrontBrakeBias = packet.FrontBrakeBias,
                IsCurrentLapInvalid = packet.CurrentLapInvalid == 1,
                DamageInfo = new DamageInfo
                {
                    Engine = packet.EngineDamage,
                    FrontwingLeft = packet.FrontLeftWingDamage,
                    FrontwingRight = packet.FrontRightWingDamage,
                    Exhaust = packet.ExhaustDamage,
                    Gearbox = packet.GearBoxDamage,
                    Rearwing = packet.RearWingDamage,
                    Tyres = packet.TyresDamage.Cast<uint>().ToArray().ParseWheelInfo()
                },
                IsPitLimiterOn = packet.PitLimiterStatus == 1,
                SessionTimeLeft = packet.SessionTimeLeft.ToTimeSpan(),
                RevLightsPercentage = packet.RevLightsPercent,
                Yaw = packet.Yaw,
                Pitch = packet.Pitch,
                Roll = packet.Roll,
                LocalVelocity = new XYZ(packet.XLocalVelocity, packet.YLocalVelocity, packet.ZLocalVelocity),
                SuspensionAcceleration = packet.SuspAcceleration.ParseWheelInfo(),
                AngularAcceleration = new XYZ(packet.AngAccX, packet.AngAccY, packet.AngAccZ)
            };
        }

        private SessionData InitSessionData() => new SessionData
        {
            SessionLiveData = new List<SessionLiveData>()
        };
    }
}
