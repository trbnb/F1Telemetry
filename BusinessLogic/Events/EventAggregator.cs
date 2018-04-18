using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Events
{
    public class EventAggregator
    {
        private List<IEventFactory<IEvent>> _eventFactories = new List<Events.IEventFactory<IEvent>>();

        public event EventHandler<IEvent> EventCreated;

        public EventAggregator()
        {
            _eventFactories.ForEach(factory =>
            {
                factory.EventCreated += (_, ev) => EventCreated?.Invoke(this, ev);
            });
        }
    }
}
