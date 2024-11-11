using TMPro;
using UnityEngine;
using ZooWorld.UI.MessageDisplay.Abstraction;

namespace ZooWorld.UI.MessageDisplay.Realization
{
    public class MessageDisplayView : MonoBehaviour, IMessageDisplayView
    {
        [SerializeField] private GameObject messagePrefab;

        public void ShowMessage(string message, Vector3 position)
        {
            GameObject messageInstance = Instantiate(messagePrefab, position + Vector3.up * 2f, Quaternion.identity);
            var text = messageInstance.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.text = message;
            }
            Destroy(messageInstance, 2f);
        }
    }
}