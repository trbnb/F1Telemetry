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

        private Task emittingTask;
        private CancellationTokenSource emittingTaskCancellationTokenSource;

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
            emittingTaskCancellationTokenSource = new CancellationTokenSource();
            emittingTask = Task.Factory.StartNew(Emitting, emittingTaskCancellationTokenSource.Token);
        }

        private void Emitting()
        {
            udpPackets.ForEach(async packet =>
            {
                emittingTaskCancellationTokenSource.Token.ThrowIfCancellationRequested();
                OnUdpPacketReceived(packet);
                await Task.Delay(interval);
            });

            if (loop)
            {
                Start();
            }
        }

        public override void Pause()
        {
            emittingTaskCancellationTokenSource.Cancel();
        }
    }
}
