using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.GameLoop;
using UnityEngine;

namespace Scripts.Blocks
{
    public class UnTouchableWallBlock :Block
    {
        private GamePlayState GamePlayState => GetComponentInParent<GamePlayState>();
        protected override void OnTrigger(Collider2D other)
        {
            GamePlayState.OnGameFailed();
            TimeScaleGameState.GetInstance.OnLevelFailed();
        }
    }
}

