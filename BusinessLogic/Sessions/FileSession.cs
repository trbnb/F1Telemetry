using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelemetryHandling.UDP;
using UdpTestApp;
using Utils;

namespace BusinessLogic.Sessions
{
    public class FileSession : Session
    {
        private readonly UDPPacket[] udpPackets;
        private readonly bool loop;
        private readonly int interval;
        
        private CancellationTokenSource _emittingTaskCancellationTokenSource;

        public FileSession(string absolutePath, bool loop, int interval)
        {
            this.loop = loop;
            this.interval = interval;

            var bytes = File.ReadAllBytes(absolutePath);
            udpPackets = bytes.Split(Constants.PackageSize)
                .Select(StructHelpers.ConvertToPacket<UDPPacket>)
                .ToArray();
        }

        public override void Start()
        {
            IsRunning = true;
            _emittingTaskCancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(Emitting, _emittingTaskCancellationTokenSource.Token);
        }

        private async void Emitting()
        {
            foreach (var udpPacket in udpPackets)
            {
                if (_emittingTaskCancellationTokenSource.Token.IsCancellationRequested)
                {
                    return;
                }
                OnUdpPacketReceived(udpPacket);
                await Task.Delay(interval);
            }

            if (loop)
            {
                Start();
            }
            else
            {
                IsRunning = false;
            }
        }

        public override void Pause()
        {
            IsRunning = false;
            _emittingTaskCancellationTokenSource?.Cancel();
        }
    }
}
