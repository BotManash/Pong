using Scripts.Global;
using Scripts.UIHandler.ButtonUI;
using UnityEngine;

namespace Scripts.UIHandler
{
    public class GoToNextLevelUI : ButtonUi
    {
        protected override void OnClickFunc()
        {
            var nextLevelIndex = PlayerPrefs.GetInt(ConstantKey.CurrentUnlockedLevel);
            PlayerPrefs.SetInt(ConstantKey.SelectedLevelIndex,nextLevelIndex);
            SceneView.GetInstance.LoadScene(3,2f);
        }
    }
}