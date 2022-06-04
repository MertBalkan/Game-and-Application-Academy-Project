using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AcademyProject.Managers
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        private List<AudioSource> _audios;

        private bool _losePlayed = false;
        private bool _slingShotPlayed = false;
        private bool _playerHitPlayed = false;

        public bool PlayerHitPlayed
        {
            get => _playerHitPlayed;
            set => _playerHitPlayed = value;
        }
        
        private void Awake()
        {
            ApplySingleton(this);
        }

        private void Start()
        {
            _audios = GetComponentsInChildren<AudioSource>().ToList();
            GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
        }

        private void HandleOnScoreChanged(int score)
        {
            PlayScoreSound();
            PlayHitSound();
        }

        public void PlayScoreSound()
        {
            _audios[0].Play();
        } 
        
        public void PlayHitSound()
        {
            _audios[1].Play();
        } 
        
        public void PlayDoorOpenSound()
        {
            _audios[2].Play();
        }

        public void PlayGrabSound()
        {
            _audios[3].Play();
        }
        
        public void PlayWaveEndSound()
        {
            _audios[4].Play();
            _losePlayed = false;
        }

        public void PlayGameLoseSound()
        {
            if (!_losePlayed)
            {
                _audios[5].Play();
                _losePlayed = true;
            }
        }

        public void SlingSound()
        {
            if (!_slingShotPlayed)
            {
                _audios[6].Play();
                _slingShotPlayed = true;
            }
        }

        public void SlingShotSound()
        {
            _audios[7].Play();
            _slingShotPlayed = false;
        }

        public void PlayerHitSound()
        {
            if (!_playerHitPlayed)
            {
                _audios[8].Play();
                _playerHitPlayed = true;
            }
        }
    }
}
