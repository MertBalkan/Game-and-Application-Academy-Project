using UnityEngine;

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
    }
}