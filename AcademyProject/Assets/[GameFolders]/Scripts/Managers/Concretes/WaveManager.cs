using System.Collections.Generic;
using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.Managers
{
    /// <summary>
    /// Controlling Wave Logic
    /// </summary>
    public class WaveManager : SingletonMonoBehaviour<WaveManager>
    {
        [SerializeField] private int maxWaveCount;
        [SerializeField] private int enemyCoefficientPerWave;
        
        private List<EnemyController> _enemies;
        private int _totalSpawnPointCount;
        private int _deadEnemyCount;
        private int _currentWave = 1;
        private int _currentWaveEnemyCount;

        public event System.Action OnWaveFinished;
        public bool CanPassNextWave => _deadEnemyCount == _currentWaveEnemyCount;

        public int DeadEnemyCount
        {
            get => _deadEnemyCount;
            set => _deadEnemyCount = value;
        }
        
        public int CurrentWaveEnemyCount
        {
            get => _currentWaveEnemyCount;
            set => _currentWaveEnemyCount = value;
        }
        
        public int TotalSpawnPointCount
        {
            get => _totalSpawnPointCount;
            set =>  _totalSpawnPointCount = value;
        }
                
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
            FinishWave();

            Debug.Log("CURRENT WAVE:" + _currentWave);
        }

        public void SetEnemies(EnemyController enemy)
        {
            _enemies.Add(enemy);
        }

        public void StartWave()
        {
            Debug.Log("New wave started");
            _currentWave++;
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