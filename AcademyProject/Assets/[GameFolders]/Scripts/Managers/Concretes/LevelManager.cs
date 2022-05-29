using System;
using AcademyProject.AIs;
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
        
        private void Awake()
        {
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
            _levelStateMachine.ReturnCurrentLevelState().LevelUpdateState();
            // Just for test...
            _levelStateMachine.NextLevelState(_currentLevelState = new SpawnEnemiesState(), ()=>Input.GetKeyDown(KeyCode.P));
        }
    }   
}
