using System;
using System.Collections.Generic;
using System.Text;
using F1Telemetry.Models;
using Models;
using TelemetryHandling.UDP;

namespace BusinessLogic.Sessions
{
    public abstract class Session
    {
        private SessionData _sessionData = null;
        public SessionData SessionData {
            get => _sessionData;
            protected set
            {
                _sessionData = value;
                SessionDataUpdated?.Invoke(this, _sessionData);
            }
        }

        public event EventHandler<SessionData> SessionDataUpdated;
        public event EventHandler<Exception> ExceptionThrown;

        public bool IsRunning { get; protected set; }

        private readonly SessionConverter _sessionConverter = new SessionConverter();

        protected void OnUdpPacketReceived(UDPPacket packet)
        {
            try
            {
                SessionData = _sessionConverter.Convert(SessionData, packet);
            }
            catch (Exception e)
            {
                ExceptionThrown?.Invoke(this, e);
            }
        }

        public abstract void Start();
        public abstract void Pause();
    }
}
