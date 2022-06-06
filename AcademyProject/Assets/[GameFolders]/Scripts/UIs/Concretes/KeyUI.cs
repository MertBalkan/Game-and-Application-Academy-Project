using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.Managers;
using TMPro;
using UnityEngine;

namespace AcademyProject.UIs
{
    public class KeyUI : MonoBehaviour
    {
        private TextMeshProUGUI _keyText;

        private void Awake()
        {
            _keyText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            WaveManager.Instance.OnWaveFinished += HandleOnWaveFinished;
        }

        private void HandleOnWaveStarted()
        {
            _keyText.gameObject.SetActive(false);
        }

        private void HandleOnWaveFinished()
        {
            _keyText.gameObject.SetActive(true);
        }

        private void OnDisable()
        {    
            WaveManager.Instance.OnWaveFinished -= HandleOnWaveFinished;
        }
    }
}