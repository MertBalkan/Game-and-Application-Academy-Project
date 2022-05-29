using UnityEngine;

namespace AcademyProject.States
{
    public class SpawnEnemiesState : ILevelState
    {
        public void OnLevelStateEnter()
        {
            Debug.Log("SpawnEnemiesState OnLevelStateEnter");
        }

        public void LevelUpdateState()
        {
            Debug.Log("SpawnEnemiesState LevelUpdateState");
        }

        public void OnLevelStateExit()
        {
            Debug.Log("SpawnEnemiesState OnLevelStateExit");
        }
    }
}