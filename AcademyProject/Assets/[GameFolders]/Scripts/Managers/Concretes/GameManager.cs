using UnityEngine;
using UnityEngine.SceneManagement;

namespace AcademyProject.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        #region Score Logic

        private int _totalScore;
        public int TotalScore => _totalScore;
        public event System.Action<int> OnScoreChanged;
        
        #endregion

        private void Awake()
        {
            ApplySingleton(this);
        }

        public void UpdateScore(int score)
        {
            _totalScore += score;
            OnScoreChanged?.Invoke(score);
        }
        
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadSceneByBuildIndex()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}