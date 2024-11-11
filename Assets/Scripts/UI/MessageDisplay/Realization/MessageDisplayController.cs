using System;
using UnityEngine;
using Zenject;
using ZooWorld.Animals.Events;
using ZooWorld.EventBus.Abstraction;
using ZooWorld.UI.MessageDisplay.Abstraction;

namespace ZooWorld.UI.MessageDisplay.Realization
{
    public class MessageDisplayController : IMessageDisplayController, IInitializable, IDisposable
    {
        private readonly IMessageDisplayView _view;
        private readonly IEventBus _eventBus;

        [Inject]
        public MessageDisplayController(IMessageDisplayView view, IEventBus eventBus)
        {
            _view = view;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<ShowMessageEvent>(OnShowMessage);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ShowMessageEvent>(OnShowMessage);
        }

        private void OnShowMessage(ShowMessageEvent eventData)
        {
            ShowMessage(eventData.Message, eventData.Position);
        }

        public void ShowMessage(string message, Vector3 position)
        {
            _view.ShowMessage(message, position);
        }
    }
}