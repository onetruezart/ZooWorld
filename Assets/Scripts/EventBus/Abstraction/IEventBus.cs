namespace ZooWorld.EventBus.Abstraction
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(System.Action<TEvent> handler);
        void Unsubscribe<TEvent>(System.Action<TEvent> handler);
        void Publish<TEvent>(TEvent eventData);
    }
}