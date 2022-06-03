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

        #region Lose Game Logic

        public event System.Action<bool> OnGameLose;

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

        public void LoseGame(bool loseCondition)
        {
            OnGameLose?.Invoke(loseCondition);
            Invoke("LoadSelfScene", 3.0f);
        }
        
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadNextScene()
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