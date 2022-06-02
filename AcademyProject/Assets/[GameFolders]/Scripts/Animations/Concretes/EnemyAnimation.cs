using AcademyProject.AIs;
using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.Animations
{
    public class EnemyAnimation : ICharacterAnimation
    {
        private IEnemyAI _enemy;
        private Animator _enemyAnimator;
        
        public EnemyAnimation(IEnemyAI enemy)
        {
            _enemy = enemy;
            _enemyAnimator = enemy.EnemyAnimator;
        }
        
        public void MovementAnimation(float speed)
        {
            if(speed == 0) return;
            _enemyAnimator.SetFloat("speed", speed);
        }

        public void DieAnimation()
        {
            _enemyAnimator.SetTrigger("die");
        }

        public void CollectAnimation(){ }
        public void SlingWeaponAnimation(float slingTime, bool readyFire) {}
    }
}