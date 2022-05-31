using AcademyProject.Managers;
using TMPro;
using UnityEngine;

namespace AcademyProject.UIs
{
    public class WaveUI : MonoBehaviour
    {
        private TextMeshProUGUI _waveText;

        private void Awake()
        {
            _waveText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            WaveManager.Instance.OnWaveStarted += HandleOnWaveStarted;
        }

        private void OnDisable()
        {    
            WaveManager.Instance.OnWaveStarted -= HandleOnWaveStarted;
        }

        private void HandleOnWaveStarted()
        {
            _waveText.text = "Wave "+ WaveManager.Instance.CurrentWave.ToString();
        }
    }
}