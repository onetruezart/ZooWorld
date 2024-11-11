using UnityEngine;

namespace ZooWorld.UI.MessageDisplay.Abstraction
{
    public interface IMessageDisplayView
    {
        void ShowMessage(string message, Vector3 position);
    }
}