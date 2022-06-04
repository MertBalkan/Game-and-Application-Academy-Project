using System;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyProject.Managers
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField] private List<AudioSource> audios;
        
        private void Awake()
        {
            ApplySingleton(this);
        }

        private void Start()
        {
            GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
        }

        private void HandleOnScoreChanged(int score)
        {
            PlayScoreSound();
        }

        public void PlayScoreSound()
        {
            audios[0].Play();
        }
    }
}
