using System;
using System.Collections;
using AcademyProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private Image time;
        [SerializeField] private Text  timeText;
        [SerializeField] private float currentTime;
        [SerializeField] private float duration;

        private float _minute;
        private float _seconds;
        
        public bool IsTimerFinished => (_minute == 0 && _seconds == 0);
        
        void Start()
        {
            currentTime = duration;
            _minute = Mathf.FloorToInt(currentTime / 60);
            _seconds = Mathf.FloorToInt(currentTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", _minute, _seconds);
            StartCoroutine(CountdownTime());

            WaveManager.Instance.OnWaveFinished += HandleOnWaveFinished;
        }

        private void OnDisable()
        {  
            WaveManager.Instance.OnWaveFinished -= HandleOnWaveFinished;
        }

        private void HandleOnWaveFinished()
        {
            currentTime = 5; // hardcode for now
            StartCoroutine(CountdownTime());
            
            //-----MANAGERS-----\\
            WaveManager.Instance.StartWave();
            LevelManager.Instance.IsSpawnStateDone = false;
            WaveManager.Instance.DeadEnemyCount = 0;
        }

        private IEnumerator CountdownTime()
        {
            while (currentTime >= 0)
            {
                time.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
                _minute = Mathf.FloorToInt(currentTime / 60);
                _seconds = Mathf.FloorToInt(currentTime % 60);
                timeText.text = string.Format("{0:00}:{1:00}", _minute, _seconds);
                yield return new WaitForSeconds(1f);
                currentTime--;
                time.fillAmount = currentTime;
            }
            yield return null;
        }
    }
}