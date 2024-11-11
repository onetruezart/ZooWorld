namespace ZooWorld.UI.DeathCounter.Abstraction
{
    public interface IDeathCounterView
    {
        void SetPreyDeathCount(int count);
        void SetPredatorDeathCount(int count);
    }
}