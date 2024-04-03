using AudioHandler;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.UIHandler.ButtonUI
{
    public abstract class ButtonUi : MonoBehaviour,IPointerClickHandler
    {

        [SerializeField] protected AudioClip buttonSound;
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioSystem.GetInstance.PlayOnce(buttonSound);
            OnClickFunc();
        }

        protected abstract void OnClickFunc();
    }
}

