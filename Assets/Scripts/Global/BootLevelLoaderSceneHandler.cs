using UnityEngine;

namespace Scripts.Global
{
    public class BootLevelLoaderSceneHandler : MonoBehaviour
    {
        public void CompleteBootLoaderScene()
        {
            SceneView.GetInstance.LoadScene(1,2f);
        }
    
    
    
    }
}

