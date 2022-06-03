using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.Managers;
using UnityEngine;

namespace AcademyProject.UIs
{
     /// <summary>
     /// Game Over UI
     /// </summary>
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;

        private void Start()
        {
            gameOverPanel.SetActive(false);
            GameManager.Instance.OnGameLose += HandleOnGameLose;
        }
        
        private void OnDisable()
        {
            GameManager.Instance.OnGameLose -= HandleOnGameLose;
        }

        private void HandleOnGameLose(bool loseCondition)
        {
            if (loseCondition)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}