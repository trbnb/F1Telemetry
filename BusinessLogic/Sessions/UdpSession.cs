using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using F1Telemetry.Models;
using TelemetryHandling;

namespace BusinessLogic.Sessions
{
    public class UdpSession : Session
    {
        private readonly TelemetryClient telemetryClient;

        public UdpSession(string ipAddress, int port)
            : this(IPAddress.Parse(ipAddress), port)
        {
        }

        public UdpSession(IPAddress ipAddress, int port)
        {
            telemetryClient = new TelemetryClient(ipAddress, port);
            telemetryClient.PacketReceived += (_, packet) => OnUdpPacketReceived(packet);
        }

        public override void Start()
        {
            IsRunning = true;
            telemetryClient.StartListening();
        }

        public override void Pause()
        {
            IsRunning = false;
            telemetryClient.StopListening();
        }
    }
}
