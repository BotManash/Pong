using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameLoop
{
    public class RandomSceneChoose : MonoBehaviour
    {
        [SerializeField] private List<RandomSceneProfile> randomSceneProfile;

        private void Start()
        {
            GetRandomScene();
        }

        private void GetRandomScene()
        {
            var randomNumberSelection = Random.Range(0, 3);
            for (var i = 0; i < randomSceneProfile.Count; i++)
            {
                if (randomNumberSelection != randomSceneProfile[i].sceneId)
                {
                    continue;
                }
                randomSceneProfile[i].sceneObject.SetActive(true);
            }
        }
    }

    [Serializable]
    public class RandomSceneProfile
    {
        public int sceneId;
        public string sceneName;
        public GameObject sceneObject;
    }
}

