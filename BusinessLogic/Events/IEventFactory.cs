using System;
using System.Collections.Generic;
using System.Text;
using TelemetryHandling.UDP;

namespace BusinessLogic.Events
{
    public interface IEventFactory<out E>
        where E : IEvent
    {
        event EventHandler<E> EventCreated;

        void Process(UDPPacket packet);
    }
}
