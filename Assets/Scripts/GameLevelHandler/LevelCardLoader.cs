using System;
using System.Collections.Generic;
using AudioHandler;
using Scripts.Global;
using UnityEngine;

namespace Scripts.GameLevelHandler
{
    public class LevelCardLoader : MonoBehaviour
    {
        [SerializeField] private List<LevelCardObject> levelProfile;
        [SerializeField] private LevelCard levelCard;
        [SerializeField] private Transform levelContent;
        [SerializeField] private AudioClip levelClickAudio;
        [SerializeField] private List<LevelCard> currentLevelCardList;
        
        
        private void Start()
        {
            currentLevelCardList = new List<LevelCard>();
            SpawnLevelCard();
        }

        private void OnDisable()
        {
            ClearLevelCard();
        }

        private void SpawnLevelCard()
        {
            foreach (var item in levelProfile)
            {
                var levelObject = Instantiate(levelCard, levelContent);
                levelObject.LevelIndex = item.LevelIndex;
                item.isLocked = item.LevelIndex > PlayerPrefs.GetInt(ConstantKey.CurrentUnlockedLevel);
                levelObject.textObject.text = item.LevelIndex.ToString();
                levelObject.OnClickEvent += LoadLevelSelectionButtonExtras;
                if (item.isLocked)
                {
                    levelObject.levelLockImage.SetActive(true);
                }
                else
                {
                    levelObject.OnLoadLevel += LoadLevel;
                    levelObject.levelLockImage.SetActive(false);
                }
                currentLevelCardList.Add(levelObject);
            }
        }

      
        private void ClearLevelCard()
        {
            foreach (var levelCards in currentLevelCardList)
            {
                Destroy(levelCards);
            }
            currentLevelCardList.Clear();
        }
        

        private void LoadLevel(int levelIndex)
        {
            SceneView.GetInstance.LoadScene(3,1f);
            PlayerPrefs.SetInt(ConstantKey.SelectedLevelIndex,levelIndex);
        }
        private void LoadLevelSelectionButtonExtras()
        {
            AudioSystem.GetInstance.PlayOnce(levelClickAudio);
        }

    }
}