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
        private readonly IPAddress _ipAddress;
        private readonly int _port;

        private UdpClient _udpClient;
        public bool IsListening { get; private set; } = false;

        public event EventHandler<UDPPacket> PacketReceived;
        public event EventHandler<Exception> ExceptionThrown;

        public TelemetryClient(string ipAddress = "127.0.0.1", int port = 20777)
            : this(IPAddress.Parse(ipAddress), port)
        {
        }

        public TelemetryClient(IPAddress ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public void StartListening()
        {
            _udpClient = new UdpClient(new IPEndPoint(_ipAddress, _port));
            IsListening = true;
            Task.Factory.StartNew(Listen);
        }

        public void StopListening()
        {
            _udpClient?.Dispose();
            IsListening = false;
        }

        private async void Listen()
        {
            while (IsListening)
            {
                try
                {
                    if (_udpClient == null)
                    {
                        StopListening();
                        return;
                    }

                    var result = await _udpClient.ReceiveAsync();
                    var bytes = result.Buffer;
                    var item = bytes.ConvertToPacket<UDPPacket>();
                    PacketReceived?.Invoke(this, item);
                }
                catch(Exception e)
                {
                    ExceptionThrown?.Invoke(this, e);
                }
            }
        }
    }
}
