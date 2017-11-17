using System;
using System.Collections.Generic;
using System.Text;
using TelemetryHandling.UDP;
using F1Telemetry.Models;

namespace BusinessLogic
{
    // TODO: Automapper shoul dbe used for this one
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


            }

            return sessionData;
        }

        private static SessionData InitSessionData() => new SessionData
        {
            CarInfo = new CarInfo[20],
            SessionLiveData = new List<SessionLiveData>()
        };

        private SessionLiveData InitSessionLiveData() => new SessionLiveData
        {
            CarLiveData = new CarLiveData[20]
        };
    }
}
