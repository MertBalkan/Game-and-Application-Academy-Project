using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.States
{
    public class SpawnEnemiesState : ILevelState
    {
        private SpawnerController _spawner;
        
        public SpawnEnemiesState(SpawnerController spawner)
        {
            _spawner = spawner;
        }
        public void OnLevelStateEnter()
        {
            _spawner.StartToSpawnEnemy(true);
        }

        public void LevelUpdateState()
        {
            Debug.Log("SpawnEnemiesState LevelUpdateState");
        }

        public void OnLevelStateExit()
        {
            _spawner.StartToSpawnEnemy(false);
        }
    }
}