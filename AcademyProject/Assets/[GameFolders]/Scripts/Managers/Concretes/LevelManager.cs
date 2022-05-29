using System;
using AcademyProject.AIs;
using AcademyProject.Controllers;
using AcademyProject.States;
using UnityEngine;

namespace AcademyProject.Managers
{
    /// <summary>
    /// Controlling Level From Level Manager
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private IEnemyAI[] _enemies;
        
        private ILevelState _currentLevelState;
        private LevelStateMachine _levelStateMachine;

        private SpawnerController _spawnerController;
        
        private void Awake()
        {
            _spawnerController = FindObjectOfType<SpawnerController>();
            _levelStateMachine = new LevelStateMachine(new WaitLevelState());
            
            // _currentLevelState = new SpawnState()
            // _currentLevelState = new PlayLevelState()
            // _currentLevelState = new WaveEndState()
            // _currentLevelState = new FinishGameState();
        }

        private void Start()
        {
            _currentLevelState = _levelStateMachine.ReturnCurrentLevelState();
        }
        

        private void Update()
        {
            PrintState();
            // Just for test...
            if (Input.GetKeyDown(KeyCode.P))
            {
                _levelStateMachine.NextLevelState(_currentLevelState = new SpawnEnemiesState(), _spawnerController.StartToSpawnEnemy(true));
            }
        }

        private void PrintState()
        {
            _levelStateMachine.ReturnCurrentLevelState().OnLevelStateEnter();
        }
    }   
}
