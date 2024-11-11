namespace ZooWorld.UI.DeathCounter.Abstraction
{
    public interface IDeathCounterPresenter
    {
        void OnPreyDied();
        void OnPredatorDied();
    }
}