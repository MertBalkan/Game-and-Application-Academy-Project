using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.Animations
{
    public class PlayerAnimation : ICharacterAnimation
    {
        private PlayerCharacterController _player;
        private Animator _playerAnimator;

        private bool isDead = false;
        
        public PlayerAnimation(PlayerCharacterController player)
        {
            _player = player;
            _playerAnimator = _player.GetComponent<Animator>();
        }
        
        public void MovementAnimation(float speed)
        {
            _playerAnimator.SetFloat("speed", Mathf.Abs(speed), 0.09f, Time.deltaTime);
        }

        public void DieAnimation()
        {
            if (!isDead)
            {
                isDead = true;
                _playerAnimator.SetTrigger("die");
            }
        }

        public void CollectAnimation()
        {
            _playerAnimator.SetTrigger("collect");
        }

        public void SlingWeaponAnimation(float slingTime, bool readyFire)
        {
            _playerAnimator.SetFloat("slingTime", slingTime);
            _playerAnimator.SetBool("readyFire", readyFire);
        }

        public void AttackAnimation(bool attack)
        {
            attack = false;
        }
    }
}