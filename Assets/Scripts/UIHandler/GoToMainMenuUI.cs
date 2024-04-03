using Scripts.Global;
using Scripts.UIHandler.ButtonUI;

namespace Scripts.UIHandler
{
    public class GoToMainMenuUI: ButtonUi
    {
        protected override void OnClickFunc()
        {
            SceneView.GetInstance.LoadScene(2,2f);
        }
    }
}