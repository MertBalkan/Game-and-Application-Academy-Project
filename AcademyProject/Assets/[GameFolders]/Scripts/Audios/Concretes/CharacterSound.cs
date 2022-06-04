using System;
using AcademyProject.Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AcademyProject.Audios
{
    public class CharacterSound : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterController player;
        private AudioSource[] _footstepAudios;

        private int _footStepSoundRandomize;
        private bool IsPlayerMoving => (player.Input.HorizontalMovement != 0 || player.Input.VerticalMovement != 0);

        private void Awake()
        {
            _footstepAudios = GetComponentsInChildren<AudioSource>();
        }

        private void Update()
        {
            FootStepSounds();
        }

        private void FootStepSounds()
        {
            if (IsPlayerMoving) _footStepSoundRandomize = Random.Range(0, _footstepAudios.Length);
            
            if (!_footstepAudios[_footStepSoundRandomize].isPlaying && IsPlayerMoving)
            {
                _footstepAudios[_footStepSoundRandomize].volume = Random.Range(0.01f, 0.02f);
                _footstepAudios[_footStepSoundRandomize].pitch = Random.Range(0.8f, 1.1f);
                _footstepAudios[_footStepSoundRandomize].Play(); 
            }
        }
    }
}