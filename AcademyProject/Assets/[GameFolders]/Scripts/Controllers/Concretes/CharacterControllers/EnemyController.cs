using System;
using AcademyProject.AIs;
using AcademyProject.Animations;
using AcademyProject.Combats;
using AcademyProject.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace AcademyProject.Controllers
{
    public class EnemyController : BaseCharacterController, IEnemyAI
    {
        private NavMeshAgent _navMeshAgent;
        private PlayerCharacterController _player;

        public Animator EnemyAnimator => this.GetComponent<Animator>();

        private ICharacterAnimation _enemyAnimation;

        public ICharacterAnimation EnemyAnimation => _enemyAnimation;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerCharacterController>();
            _enemyAnimation = new EnemyAnimation(this);
        }
        
        private void Update()
        {
            if(_player == null) return;
            if (this.GetComponent<IHealth>().IsDead)
            {
                _navMeshAgent.speed = 0;
                return;
            }
            
            _navMeshAgent.SetDestination(_player.transform.position);
            _enemyAnimation.MovementAnimation(_navMeshAgent.speed);
        }

        private void OnDestroy()
        {
            WaveManager.Instance.EnemyDead(this);
        }

    }
}