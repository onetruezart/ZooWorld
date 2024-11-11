using System;
using UnityEngine;
using Zenject;

namespace ZooWorld.UI.MessageDisplay.Abstraction
{
    public interface IMessageDisplayController
    {
        void ShowMessage(string message, Vector3 position);
    }
}