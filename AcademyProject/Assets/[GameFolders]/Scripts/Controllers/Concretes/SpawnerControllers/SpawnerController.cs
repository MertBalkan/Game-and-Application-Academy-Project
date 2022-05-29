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

        public event Func<bool> OnStartSpawned;

        private void Start()
        {
            _spawnPoints = FindObjectsOfType<SpawnPointController>().ToList();
            OnStartSpawned += () => true;
        }

        public Func<bool> StartToSpawnEnemy(bool obj)
        {
            if (obj)
            {
                foreach (var spawnPoint in _spawnPoints)
                    Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);      
            }

            return OnStartSpawned;
        }
    }
}