using System;
using System.Collections.Generic;
using System.Linq;
using AcademyProject.Controllers;
using AcademyProject.UIs;
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
        private CountDown _countDown;
        private int _totalSpawnPointCount;
        private int _deadEnemyCount;
        private int _currrentWave = 1;
        private int _currentWaveEnemyCount;

        public event System.Action OnWaveFinished;
        public bool CanPassNextWave => _currrentWave <= maxWaveCount;

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
            _countDown = FindObjectOfType<CountDown>();
            _enemies = new List<EnemyController>();
        }

        private void Start()
        {
            _currentWaveEnemyCount = -1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                FinishWave();
                Debug.Log("WAVE FINISHED!");
            }

            if (_deadEnemyCount == _currentWaveEnemyCount)
            {
                _currrentWave++;
                _currentWaveEnemyCount = -1;
            }

            Debug.Log("CURRENT WAVE:" + _currrentWave);
        }

        public void SetEnemies(EnemyController enemy)
        {
            _enemies.Add(enemy);
        }

        public void FinishWave()
        {
            if (CanPassNextWave)
            {
                OnWaveFinished?.Invoke();
            }
        }

        public void EnemyDead(EnemyController enemy)
        { 
            _deadEnemyCount += 1;
            _enemies.Remove(enemy);
        }
    }
}