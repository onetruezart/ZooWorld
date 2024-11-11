using System;
using System.Collections.Generic;
using ZooWorld.EventBus.Abstraction;

namespace ZooWorld.EventBus.Realization
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _subscribers = new Dictionary<Type, List<object>>();

        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            var eventType = typeof(TEvent);
            if (!_subscribers.TryGetValue(eventType, out var handlers))
            {
                handlers = new List<object>();
                _subscribers[eventType] = handlers;
            }
            handlers.Add(handler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler)
        {
            var eventType = typeof(TEvent);
            if (_subscribers.TryGetValue(eventType, out var handlers))
            {
                handlers.Remove(handler);
            }
        }

        public void Publish<TEvent>(TEvent eventData)
        {
            var eventType = typeof(TEvent);
            if (_subscribers.TryGetValue(eventType, out var handlers))
            {
                foreach (var handlerObj in handlers)
                {
                    var handler = handlerObj as Action<TEvent>;
                    handler?.Invoke(eventData);
                }
            }
        }
    }
}