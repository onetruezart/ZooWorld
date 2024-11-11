using UnityEngine;

namespace ZooWorld.Animals.Events
{
    public class ShowMessageEvent
    {
        public string Message { get; }
        public Vector3 Position { get; }

        public ShowMessageEvent(string message, Vector3 position)
        {
            Message = message;
            Position = position;
        }
    }
}