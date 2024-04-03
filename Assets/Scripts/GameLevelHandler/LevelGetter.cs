using System.Collections.Generic;
using System.Linq;
using Scripts.Global;
using UnityEngine;

namespace Scripts.GameLevelHandler
{
    public class LevelGetter : MonoBehaviour
    {
        [SerializeField] private List<LevelObject> levelObjects;
        private void Start()
        {
            foreach (var item in levelObjects.Where(t => t.levelId == PlayerPrefs.GetInt(ConstantKey.SelectedLevelIndex)))
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}