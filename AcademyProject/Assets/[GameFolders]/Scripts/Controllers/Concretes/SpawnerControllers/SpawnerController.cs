using System;
using System.Collections.Generic;
using System.Linq;
using AcademyProject.AIs;
using AcademyProject.Managers;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        private List<SpawnPointController> _spawnPoints;
        [SerializeField] private EnemyController enemy;


        private CountDown _countDown;

        private void Awake()
        {
            _countDown = FindObjectOfType<CountDown>();
        }

        private void Start()
        {
            _spawnPoints = FindObjectsOfType<SpawnPointController>().ToList();
            WaveManager.Instance.TotalSpawnPointCount = _spawnPoints.Count;
        }

        public void StartToSpawnEnemy(bool spawnCondition)
        {
            if (spawnCondition && _countDown.IsTimerFinished)
            {
                for (var index = 0; index < _spawnPoints.Count; index++)
                {
                    var spawnPoint = _spawnPoints[index];

                    var enemyController = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
                    WaveManager.Instance.SetEnemies(enemyController);
                }
                WaveManager.Instance.CurrentWaveEnemyCount = _spawnPoints.Count;
            }
        }
    }
}