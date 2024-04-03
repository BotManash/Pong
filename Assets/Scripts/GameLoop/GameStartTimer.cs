using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.GameLoop
{
    public class GameStartTimer : MonoBehaviour
    {
        [SerializeField] private GameObject timeObject;
        [SerializeField] private TextMeshProUGUI gameTimer;
        [SerializeField] private float waitTime;

        private Coroutine _cWaitToStart;

       [SerializeField] private UnityEvent onTimerComplete;
       [SerializeField] private UnityEvent onTimeStart;
        

        private void Start()
        {
            if (_cWaitToStart != null)
            {
                _cWaitToStart = null;
            }
            else
            {
                _cWaitToStart = StartCoroutine(EWaitToStart());
            }
        }

        private IEnumerator EWaitToStart()
        {
            var currentTime = 0f;
            onTimeStart?.Invoke();
            while (currentTime<waitTime)
            {
                currentTime += Time.deltaTime;
                gameTimer.text =(waitTime-currentTime).ToString("N0");
                yield return null;
            }
            timeObject.SetActive(false);
            onTimerComplete?.Invoke();
        }

        private void OnDisable()
        {
            if (_cWaitToStart != null)
            {
                StopCoroutine(_cWaitToStart);
            }
        }
    }
}

