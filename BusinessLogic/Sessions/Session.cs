using System;
using System.Collections.Generic;
using System.Text;
using F1Telemetry.Models;
using TelemetryHandling.UDP;

namespace BusinessLogic.Sessions
{
    public abstract class Session
    {
        private SessionData sessionData = null;
        public SessionData SessionData {
            get => sessionData;
            protected set
            {
                sessionData = value;
                SessionDataUpdated(this, sessionData);
            }
        }

        public event EventHandler<SessionData> SessionDataUpdated;

        private readonly SessionConverter sessionConverter = new SessionConverter();

        protected void OnUdpPacketReceived(UDPPacket packet)
        {
            SessionData = sessionConverter.Convert(SessionData, packet);
        }

        protected abstract void Start();
        protected abstract void Pause();
    }
}
