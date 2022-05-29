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
            levelState.LevelUpdateState();
        }

        public ILevelState ReturnCurrentLevelState()
        {
            return _currentState;
        }
    }   
}
