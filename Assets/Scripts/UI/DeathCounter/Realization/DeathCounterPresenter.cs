
using System;
using Zenject;
using ZooWorld.Animals.Events;
using ZooWorld.EventBus.Abstraction;
using ZooWorld.UI.DeathCounter.Abstraction;
using ZooWorld.UI.DeathCounter.Models;

namespace ZooWorld.UI.DeathCounter.Realization
{
    public class DeathCounterPresenter : IDeathCounterPresenter, IInitializable, IDisposable
    {
        private readonly DeathCounterModel _model;
        private readonly IDeathCounterView _view;
        private readonly IEventBus _eventBus;

        [Inject]
        public DeathCounterPresenter(DeathCounterModel model, IDeathCounterView view, IEventBus eventBus)
        {
            _model = model;
            _view = view;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<PreyDieEvent>(OnPreyDiedEvent);
            _eventBus.Subscribe<PredatorDieEvent>(OnPredatorDiedEvent);
            
            _view.SetPreyDeathCount(_model.PreyDeathCount);
            _view.SetPredatorDeathCount(_model.PredatorDeathCount);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<PreyDieEvent>(OnPreyDiedEvent);
            _eventBus.Unsubscribe<PredatorDieEvent>(OnPredatorDiedEvent);
        }

        public void OnPreyDied()
        {
            _model.IncrementPreyDeathCount();
            _view.SetPreyDeathCount(_model.PreyDeathCount);
        }

        public void OnPredatorDied()
        {
            _model.IncrementPredatorDeathCount();
            _view.SetPredatorDeathCount(_model.PredatorDeathCount);
        }

        private void OnPreyDiedEvent(PreyDieEvent eventData)
        {
            OnPreyDied();
        }

        private void OnPredatorDiedEvent(PredatorDieEvent eventData)
        {
            OnPredatorDied();
        }
    }
}