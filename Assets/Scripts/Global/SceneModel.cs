using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Global
{
    public static class SceneModel 
    {
        public static IEnumerator LoadGivenScene(int sceneId,Action callBack)
        {
            var sceneManagerOperator = SceneManager.LoadSceneAsync(sceneId);
            while (!sceneManagerOperator.isDone)
            {
                yield return null;
            }
            callBack?.Invoke();
        }

       

        public static void ExitGame()
        {
            Application.Quit();
        }
    }
}

