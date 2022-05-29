using UnityEngine;

namespace AcademyProject.States
{
    public class WaitLevelState : ILevelState
    {
        public void OnLevelStateEnter()
        {
            Debug.Log("WaitLevelState OnLevelStateEnter");
        }

        public void LevelUpdateState()
        {
            Debug.Log("WaitLevelState LevelUpdateState");
        }

        public void OnLevelStateExit()
        {
            Debug.Log("WaitLevelState OnLevelStateExit");
        }
    }
}