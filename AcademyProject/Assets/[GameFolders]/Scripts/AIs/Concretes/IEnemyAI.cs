using UnityEngine;

namespace AcademyProject.AIs
{
    public interface IEnemyAI
    {
        Animator EnemyAnimator { get; }
        void EnemyAttack(Collision other, bool canAttack);
    }   
}
