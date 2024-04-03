using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scripts.GameLevelHandler
{
    public class LevelCard : MonoBehaviour,IPointerClickHandler
    {
        public int LevelIndex { get; set; }
        public GameObject levelLockImage;
        public Action OnClickEvent { get; set; }
        public Action<int> OnLoadLevel { get; set; }

        public TextMeshProUGUI textObject;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
            OnLoadLevel?.Invoke(LevelIndex);
        }
        
    }
}