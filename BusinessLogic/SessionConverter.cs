using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryHandling.UDP;
using F1Telemetry.Models;
using UdpTestApp;

namespace BusinessLogic
{
    // TODO: Automapper should be used for this one
    internal class SessionConverter
    {
        public SessionData Convert(SessionData sessionData, UDPPacket packet)
        {
            if(sessionData == null)
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
                        Team = new Team(e.TeamId, teamName)
                    };
                }).ToArray();
            }

            return sessionData;
        }

        private static SessionData InitSessionData() => new SessionData
        {
            SessionLiveData = new List<SessionLiveData>()
        };

        private SessionLiveData InitSessionLiveData() => new SessionLiveData
        {
            CarLiveData = new CarLiveData[20]
        };
    }
}
