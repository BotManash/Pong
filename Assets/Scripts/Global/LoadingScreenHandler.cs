using System.Collections;
using Scripts.GameLoop;
using UnityEngine;


namespace Scripts.Global
{
    public class LoadingScreenHandler : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;

      
        public void GetLoadingScreen(bool status)
        {
            loadingScreen.SetActive(status);
        }

        public void CloseLoadingScreen(float closeTime)
        {
            StartCoroutine(ECloseLoadingScreen(closeTime));
        }

        private IEnumerator ECloseLoadingScreen(float closeTime)
        {
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(closeTime);
            loadingScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }
}