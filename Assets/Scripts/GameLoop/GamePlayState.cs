using System;
using System.Linq;
using Scripts.Global;
using TMPro;
using UnityEngine;

namespace Scripts.GameLoop
{
    public class GamePlayState : MonoBehaviour
    {
        [SerializeField] private GameObject levelFailedUI;
        [SerializeField] private GameObject levelCompleteUI;
        [SerializeField] private TextMeshProUGUI levelName;
        [SerializeField] private int maxLevelNumber;


        private void Start()
        {
            levelName.text = $"Level : {PlayerPrefs.GetInt(ConstantKey.SelectedLevelIndex)}";
        }

        public void OnGameComplete()
        {
            levelCompleteUI.SetActive(true);
            SaveCompleteLevelIndex();
            
        }

        private void SaveCompleteLevelIndex()
        {
            var nextLevel = PlayerPrefs.GetInt(ConstantKey.SelectedLevelIndex) + 1; //currently playing level +1 
            if (nextLevel < PlayerPrefs.GetInt(ConstantKey.CurrentUnlockedLevel)) // greater than levels that has been already unlocked
            {
                return; 
            }
            if (maxLevelNumber >= nextLevel)
            {
                PlayerPrefs.SetInt(ConstantKey.CurrentUnlockedLevel,nextLevel);
                Debug.Log(PlayerPrefs.GetInt(ConstantKey.CurrentUnlockedLevel));
            }
        }

        public void OnGameFailed()
        {
            levelFailedUI.SetActive(true);
        }

    }
}

