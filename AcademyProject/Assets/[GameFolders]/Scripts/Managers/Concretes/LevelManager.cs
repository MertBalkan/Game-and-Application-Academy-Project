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
        
        private ILevelState _currentLevelState;
        private ILevelState _nextLevelState;

        private bool _isSpawnStateDone = false;

        private void Awake()
        {
            _timeUI = FindObjectOfType<CountDown>();
            _spawnerController = FindObjectOfType<SpawnerController>();
            _levelStateMachine = new LevelStateMachine(new SpawnEnemiesState(_spawnerController));

            // _currentLevelState = new WaveEndState()
            // _currentLevelState = new FinishGameState();
        }

        private void Start()
        {
            _currentLevelState = _levelStateMachine.ReturnCurrentLevelState();
        }

        private void Update()
        {
            if(!_isSpawnStateDone && _timeUI.IsTimerFinished){
                _levelStateMachine.NextLevelState(_currentLevelState, ()=>_timeUI.IsTimerFinished);
                _isSpawnStateDone = true;
            }
        }
    }   
}
