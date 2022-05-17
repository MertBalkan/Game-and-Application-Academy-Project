using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.Animations
{
    public class PlayerAnimation : ICharacterAnimation
    {
        private PlayerCharacterController _player;
        
        public PlayerAnimation(PlayerCharacterController player)
        {
            _player = player;
        }
        
        public void MovementAnimation(float speed)
        {
            _player.GetComponent<Animator>().SetFloat("speed", Mathf.Abs(speed), 0.09f, Time.deltaTime);
        }
    }
}