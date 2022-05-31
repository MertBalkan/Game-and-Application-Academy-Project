namespace AcademyProject.States
{
    public interface ILevelState
    {
        void OnLevelStateEnter();
        void LevelUpdateState();
        void OnLevelStateExit();
    }   
}
