using System.Collections;
using System.Collections.Generic;
using Scripts.Blocks;
using UnityEngine;

namespace Scripts.GameLoop
{
    public class LevelCompleteCheck : MonoBehaviour
    {
        [SerializeField] private GamePlayState gamePlayState;
        [SerializeField] private List<BlockHit> currentBlocks;

        [SerializeField] private bool hasCompletedLevel;
        private Coroutine _cCheckLevelCompleteConditionRoutine;
        private void Start()
        {
            GetCurrentLevelBlocks();
            if (_cCheckLevelCompleteConditionRoutine != null)
            {
                _cCheckLevelCompleteConditionRoutine = null;
            }
            else
            {
                _cCheckLevelCompleteConditionRoutine = StartCoroutine(EStartLevelCompleteCheck());
            }
        }

        private void OnDisable()
        {
            if (_cCheckLevelCompleteConditionRoutine != null)
            {
                StopCoroutine(_cCheckLevelCompleteConditionRoutine);
                _cCheckLevelCompleteConditionRoutine = null;
            }
        }

        private void GetCurrentLevelBlocks()
        {
            currentBlocks = new List<BlockHit>();
            var foundBlock = FindObjectsOfType<BlockHit>();
            for (var i = 0; i < foundBlock.Length; i++)
            {
                currentBlocks.Add(foundBlock[i]);
            }
        }

        //Check if all level block has been completely destroyed
        private IEnumerator EStartLevelCompleteCheck()
        {
            while (!hasCompletedLevel)
            {
                hasCompletedLevel=currentBlocks.TrueForAll(item => item.HasHit);
                yield return new WaitForSeconds(0.2f);
            }
            gamePlayState.OnGameComplete();
            TimeScaleGameState.GetInstance.OnGamePause();
        }

       
    }
}