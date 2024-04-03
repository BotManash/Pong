using Scripts.GameLoop;
using Scripts.UIHandler.ButtonUI;
using UnityEngine;

namespace Scripts.UIHandler
{
    public class SettingMenuCloseUI : ButtonUi
    {
        [SerializeField] private GameObject settingMenuUiObject;
        protected override void OnClickFunc()
        {
            TimeScaleGameState.GetInstance.OnGameResume();
            settingMenuUiObject.SetActive(false);
        }
    }
}