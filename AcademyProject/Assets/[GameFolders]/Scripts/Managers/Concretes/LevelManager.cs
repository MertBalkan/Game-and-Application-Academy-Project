using AcademyProject.AIs;
using AcademyProject.Controllers;
using AcademyProject.States;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Managers
{
    /// <summary>
    /// Controlling Level From Level Manager
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private LevelStateMachine _levelStateMachine;
        private SpawnerController _spawnerController;
        private CountDown _timeUI;
        
        private IEnemyAI[] _enemies;
        private ILevelState _currentLevelState;
        
        private void Awake()
        {
            _timeUI = FindObjectOfType<CountDown>();
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
            _levelStateMachine.NextLevelState(_currentLevelState = new SpawnEnemiesState(_spawnerController), 
                ()=>_timeUI.IsTimerFinished);

            _levelStateMachine.ReturnCurrentLevelState().OnLevelStateExit();
        }
        private void PrintState()
        {
            _levelStateMachine.ReturnCurrentLevelState().OnLevelStateEnter();
        }
    }   
}
