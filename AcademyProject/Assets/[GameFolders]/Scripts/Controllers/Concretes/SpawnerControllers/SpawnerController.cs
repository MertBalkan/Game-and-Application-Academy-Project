using System;
using System.Collections.Generic;
using System.Linq;
using AcademyProject.AIs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        private List<SpawnPointController> _spawnPoints;
        [SerializeField] private BaseCharacterController enemy;

        private void Start()
        {
            _spawnPoints = FindObjectsOfType<SpawnPointController>().ToList();
        }

        public void StartToSpawnEnemy(bool spawnCondition)
        {
            if (spawnCondition)
            {
                foreach (var spawnPoint in _spawnPoints)
                    Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);      
            }
        }
    }
}