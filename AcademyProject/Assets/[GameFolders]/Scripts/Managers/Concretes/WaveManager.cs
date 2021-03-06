using System.Collections.Generic;
using AcademyProject.Controllers;
using TMPro;
using UnityEngine;

namespace AcademyProject.Managers
{
    /// <summary>
    /// Controlling Wave Logic
    /// </summary>
    public class WaveManager : SingletonMonoBehaviour<WaveManager>
    {
        [SerializeField] private int maxWaveCount;
        [SerializeField] private GameObject gameOverPanel;
        
        private List<EnemyController> _enemies;

        private int _totalSpawnPointCount;
        private int _deadEnemyCount;
        private int _currentWave = 1;
        private int _currentWaveEnemyCount;

        public event System.Action OnWaveStarted;
        public event System.Action OnWaveFinished;
        public bool CanPassNextWave => _deadEnemyCount == _currentWaveEnemyCount;

        public int DeadEnemyCount { set => _deadEnemyCount = value; }
        public int CurrentWaveEnemyCount { set => _currentWaveEnemyCount = value; }
        public int TotalSpawnPointCount { set =>  _totalSpawnPointCount = value; }
        public int CurrentWave => _currentWave;
        
        private void Awake()
        {
            ApplySingleton(this);
            _enemies = new List<EnemyController>();
        }

        private void Start()
        {
            _currentWaveEnemyCount = -1;
        }

        private void Update()
        {
            if(maxWaveCount == _currentWave) return;
            FinishWave();

            if (_currentWave == maxWaveCount)
            {
                gameOverPanel.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

        public void SetEnemies(EnemyController enemy)
        {
            _enemies.Add(enemy);
        }

        public void StartWave()
        {
            _currentWave++;
            OnWaveStarted?.Invoke();
        }
        
        public void FinishWave()
        {
            if (CanPassNextWave)
            {
                OnWaveFinished?.Invoke();
                _currentWaveEnemyCount = -1;
            }
        }

        public void EnemyDead(EnemyController enemy)
        { 
            _deadEnemyCount += 1;
            _enemies.Remove(enemy);
        }
    }
}