using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.GameLevelHandler
{
    [CreateAssetMenu(menuName = "Level/LevelProfile")]
    public class LevelCardObject : ScriptableObject
    {
        [SerializeField] private int levelIndex;

        public int LevelIndex
        {
            get => levelIndex;
            set => levelIndex = value;
        }
        public bool isLocked;

        private void OnEnable()
        {
            isLocked = LevelIndex > PlayerPrefs.GetInt("CurrentUnlockedLevel");
        }
    }
}
