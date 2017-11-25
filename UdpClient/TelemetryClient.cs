using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TelemetryHandling.UDP;
using Utils;

namespace TelemetryHandling
{
    public class TelemetryClient
    {
        private UdpClient udpClient;
        public bool IsListening { get; private set; } = false;

        public event EventHandler<UDPPacket> PacketReceived;
        public event EventHandler<Exception> ExceptionThrown;

        public TelemetryClient(string ipAddress = "127.0.0.1", int port = 20777)
            : this(IPAddress.Parse(ipAddress), port)
        {
        }

        public TelemetryClient(IPAddress ipAddress, int port)
        {
            udpClient = new UdpClient(new IPEndPoint(ipAddress, port));
        }

        public void StartListening()
        {
            IsListening = true;
            Task.Factory.StartNew(Listen);
        }

        public void StopListening()
        {
            IsListening = false;
        }

        private async void Listen()
        {
            while (IsListening)
            {
                try
                {
                    var result = await udpClient.ReceiveAsync();
                    var bytes = result.Buffer;
                    var item = StructHelpers.ConvertToPacket<UDPPacket>(bytes);
                    PacketReceived.Invoke(this, item);
                }
                catch(Exception e)
                {
                    ExceptionThrown(this, e);
                }
            }
        }
    }
}
