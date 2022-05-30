using UnityEngine;

namespace AcademyProject.States
{
    public class LevelStateMachine
    {
        private ILevelState _currentState;

        public LevelStateMachine(ILevelState currentState)
        {
            _currentState = currentState;
        }
        
        public void NextLevelState(ILevelState levelState, System.Func<bool> condition)
        {
            if (!condition.Invoke()) return;
            
            _currentState = levelState;
            Debug.Log(_currentState);
            _currentState.OnLevelStateEnter();
        }

        public ILevelState ReturnCurrentLevelState()
        {
            return _currentState;
        }
    }   
}
