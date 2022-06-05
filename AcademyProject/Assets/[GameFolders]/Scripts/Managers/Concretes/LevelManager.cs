using AcademyProject.Controllers;
using AcademyProject.States;
using AcademyProject.UIs;

namespace AcademyProject.Managers
{
    /// <summary>
    /// Controlling Level From Level Manager
    /// </summary>
    public class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        private LevelStateMachine _levelStateMachine;
        private SpawnerController _spawnerController;
        private CountDown _timeUI;
        private PlayerCharacterController _player;
        
        private ILevelState _currentLevelState;
        private ILevelState _nextLevelState;

        private bool _isSpawnStateDone = false;

        public bool IsSpawnStateDone
        {
            get => _isSpawnStateDone;
            set => _isSpawnStateDone = value;
        }
        
        private void Awake()
        {
            ApplySingleton(this);
            _timeUI = FindObjectOfType<CountDown>();
            _spawnerController = FindObjectOfType<SpawnerController>();
            _levelStateMachine = new LevelStateMachine(new SpawnEnemiesState(_spawnerController));
            _player = FindObjectOfType<PlayerCharacterController>();

            // _currentLevelState = new WaveEndState()
            // _currentLevelState = new FinishGameState();
        }

        private void Start()
        {
            _currentLevelState = _levelStateMachine.ReturnCurrentLevelState();
        }

        private void Update()
        {
            if(_player == null) return;
            
            if (_player.Input.ResetLevel)
                GameManager.Instance.LoadSelfScene();
            
            if(!_isSpawnStateDone && _timeUI.IsTimerFinished){
                _levelStateMachine.NextLevelState(_currentLevelState, ()=>_timeUI.IsTimerFinished);
                _isSpawnStateDone = true;
            }
        }
    }   
}
