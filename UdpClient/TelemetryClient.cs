using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TelemetryHandling.UDP;

namespace TelemetryHandling
{
    public class TelemetryClient
    {
        private UdpClient udpClient;
        public bool IsListening { get; private set; } = false;

        public event EventHandler<UDPPacket> PacketReceived;
        public event EventHandler<Exception> ExceptionThrown;

        public TelemetryClient(string ipAddress = "127.0.0.1", int port = 20777)
        {
            udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(ipAddress), port));
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
                    var item = ConvertToPacket<UDPPacket>(bytes);
                    PacketReceived(this, item);
                }
                catch(Exception e)
                {
                    ExceptionThrown(this, e);
                }
            }
        }
        
        public static T ConvertToPacket<T>(byte[] bytes)
            where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var stuff = ConvertToPacket<T>(handle.AddrOfPinnedObject());
            handle.Free();
            return stuff;
        }

        public static T ConvertToPacket<T>(IntPtr ptr)
            where T : struct
        {
            return Marshal.PtrToStructure<T>(ptr);
        }
    }
}
