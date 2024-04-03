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
            var nextLevel = PlayerPrefs.GetInt(ConstantKey.SelectedLevelIndex) + 1;
            if (maxLevelNumber >= nextLevel)
            {
                PlayerPrefs.SetInt(ConstantKey.CurrentUnlockedLevel,nextLevel);
                Debug.Log(PlayerPrefs.GetInt(ConstantKey.CurrentUnlockedLevel));
            }
            levelCompleteUI.SetActive(true);
        }

        public void OnGameFailed()
        {
            levelFailedUI.SetActive(true);
        }

    }
}

