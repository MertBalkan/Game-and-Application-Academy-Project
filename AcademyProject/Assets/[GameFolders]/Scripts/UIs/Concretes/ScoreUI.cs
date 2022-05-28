using System;
using System.Collections;
using AcademyProject.Managers;
using TMPro;
using UnityEngine;

namespace AcademyProject.UIs
{
    public class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        public bool _isCollect;

        private void Awake()
        {
            _scoreText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
        }

        private void HandleOnScoreChanged(int obj)
        {
            _isCollect = true;
            _scoreText.text = "Score: "+ GameManager.Instance.TotalScore;
        }

        private void Update()
        {
            ScoreTextAnimation();
        }
        
        private void ScoreTextAnimation()
        {    
            if (_isCollect)
            {
                _scoreText.transform.localScale = Vector3.Lerp
                (
                    _scoreText.transform.localScale,
                    new Vector3(0.75f, 0.75f, 0.75f),
                    Time.deltaTime * 10
                );
                StartCoroutine(Collect());
            }

            if (!_isCollect)
            {   
                _scoreText.transform.localScale = Vector3.Lerp
                (
                    _scoreText.transform.localScale,
                    new Vector3(1f, 1f, 1f),
                    Time.deltaTime * 10
                );
            }
        }
        private IEnumerator Collect()
        {
            yield return new WaitForSeconds(0.3f);
            _isCollect = false;
        }
    }
}