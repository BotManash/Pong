using System;
using Scripts.GameLoop;
using Scripts.Global;
using UnityEngine;

namespace Scripts.Blocks
{
    public class WallBlock : MonoBehaviour
    {
        private GamePlayState GamePlayState => GetComponentInParent<GamePlayState>();
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(ConstantKey.Ball))
            {
                return;
            }
            GamePlayState.OnGameFailed();
            TimeScaleGameState.GetInstance.OnLevelFailed();
        }
    }
}

