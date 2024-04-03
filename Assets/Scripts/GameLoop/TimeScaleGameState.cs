using UnityEngine;

namespace Scripts.GameLoop
{
    public class TimeScaleGameState : MonoBehaviour
    {
        public static TimeScaleGameState GetInstance { get; private set; }
        

        public void Awake()
        {
            if (GetInstance == null)
            {
                GetInstance = this;
            }
            else if (GetInstance != null && GetInstance != this)
            {
                GetInstance = this;
            }
        }

        public void OnGamePause()
        {
            Time.timeScale = 0f;
        }

        public void OnGameResume()
        {
            Time.timeScale = 1f;
        }
        
        public void OnLevelCompleted()
        {
            Time.timeScale = 0f;
        }

        public void OnLevelFailed()
        {
            Time.timeScale = 0f;
        }

        

    }

}
