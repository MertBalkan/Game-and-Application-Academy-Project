namespace AcademyProject.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Awake()
        {
            ApplySingleton(this);
        }
    }
}