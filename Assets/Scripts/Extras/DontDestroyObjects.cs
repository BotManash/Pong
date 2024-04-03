using UnityEngine;

namespace Scripts.Extras
{
    public class DontDestroyObjects : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}