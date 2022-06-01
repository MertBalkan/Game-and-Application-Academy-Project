using System.Collections.Generic;
using AcademyProject.Controllers;
using AcademyProject.Managers;
using UnityEngine;

namespace AcademyProject.Observers
{
    public class KeyObserver : MonoBehaviour
    {
        [SerializeField] private List<KeyController> allKeys;

        private void Start()
        {
            WaveManager.Instance.OnWaveFinished += HandleOnWaveFinished;
        }

        private void OnDisable()
        {
            WaveManager.Instance.OnWaveFinished -= HandleOnWaveFinished;
        }

        private void HandleOnWaveFinished()
        {
            if(allKeys == null) return;

            for (int i = 0; i < WaveManager.Instance.CurrentWave; i++)
            {
                if (allKeys[i].gameObject == null)
                {
                    allKeys.Remove(allKeys[i]);
                    break;
                }
                allKeys[i].gameObject.SetActive(true);
            }
        }
    }
}