using Scripts.Global;
using Scripts.UIHandler.ButtonUI;
using UnityEngine;

namespace Scripts.UIHandler
{
    public class MainMenuButtonUI : ButtonUi
    {
        
        [SerializeField] private int sceneIndex;
        [SerializeField] private float closeLoadTime;
        
        protected override void OnClickFunc()
        {
            SceneView.GetInstance.LoadScene(sceneIndex,closeLoadTime);
        }
    }
}

