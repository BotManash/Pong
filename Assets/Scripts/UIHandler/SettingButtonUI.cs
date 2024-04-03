using Scripts.GameLoop;
using Scripts.UIHandler.ButtonUI;
using UnityEngine;

namespace Scripts.UIHandler
{
    public class SettingButtonUI : ButtonUi
    {
        [SerializeField] private GameObject settingMenuUiObject;
        protected override void OnClickFunc()
        {
            settingMenuUiObject.SetActive(true);
            TimeScaleGameState.GetInstance.OnGamePause();
        }
    }
}

