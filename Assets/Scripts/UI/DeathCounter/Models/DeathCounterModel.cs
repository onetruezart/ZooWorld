namespace ZooWorld.UI.DeathCounter.Models
{
    public class DeathCounterModel
    {
        public int PreyDeathCount { get; private set; }
        public int PredatorDeathCount { get; private set; }

        public void IncrementPreyDeathCount()
        {
            PreyDeathCount++;
        }

        public void IncrementPredatorDeathCount()
        {
            PredatorDeathCount++;
        }
    }
}