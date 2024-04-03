using System;
using UnityEngine;

namespace Scripts.Global
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private LoadingScreenHandler loadingSceneHandler;
        public static SceneView GetInstance { get; private set; }

        private Coroutine _cLoadScene;
        private void Awake()
        {
            
            if (GetInstance == null)
            {
                GetInstance = this;
            }
            else if (GetInstance != null && GetInstance != this)
            {
                Destroy(this);
            }
        }

       
        public void LoadScene(int index,float closeTime)
        {
            if (_cLoadScene != null)
            {
                StopCoroutine(_cLoadScene);
                _cLoadScene = null;
            }
            loadingSceneHandler.GetLoadingScreen(true);
            StartCoroutine(SceneModel.LoadGivenScene(index, () =>
            {
                loadingSceneHandler.CloseLoadingScreen(closeTime);
            }));
        }
    }

}
