using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZooWorld.UI.DeathCounter.Abstraction;

namespace ZooWorld.UI.DeathCounter.Realization
{
    public class DeathCounterView : MonoBehaviour, IDeathCounterView
    {
        [SerializeField] private TMP_Text preyDeathCounterText;
        [SerializeField] private TMP_Text predatorDeathCounterText;
        
        private void Awake()
        {
            SetPreyDeathCount(0);
            SetPredatorDeathCount(0);
        }

        public void SetPreyDeathCount(int count)
        {
            preyDeathCounterText.text = $"Prey Deaths: {count}";
        }

        public void SetPredatorDeathCount(int count)
        {
            predatorDeathCounterText.text = $"Predator Deaths: {count}";
        }
    }
}