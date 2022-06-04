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

        private void Start()
        {
            GameManager.Instance.OnGameLose += HandleOnGameLose;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameLose -= HandleOnGameLose;
        }

        private void Update()
        {
            if(_player == null) return;
            if (this.GetComponent<IHealth>().IsDead)
            {
                _navMeshAgent.speed = 0;
                return;
            }
            
            if(FindObjectOfType<PlayerCharacterController>().GetComponent<IHealth>().IsDead) return;
            
            _navMeshAgent.SetDestination(_player.transform.position);
            _enemyAnimation.MovementAnimation(_navMeshAgent.speed);
            
            
            if (Vector3.Distance(_player.transform.position, transform.position) >= _navMeshAgent.stoppingDistance)
            {
                _enemyAnimation.AttackAnimation(false);
                _navMeshAgent.destination = _player.transform.position;
            }

            if (Vector3.Distance(_player.transform.position, transform.position) <= _navMeshAgent.stoppingDistance)
            {
                _enemyAnimation.AttackAnimation(true);
                this.transform.LookAt(_player.transform);
            }
        }

        private void OnDestroy()
        {
            WaveManager.Instance.EnemyDead(this);
        }

        private void OnCollisionStay(Collision other)
        {
            EnemyAttack(other, true);
        }

        private void OnCollisionExit(Collision other)
        {
            EnemyAttack(other, false);
        }  
        
        private void HandleOnGameLose(bool loseCondition)
        {
            if (loseCondition)
                TurnBack();
        }
        
        public void EnemyAttack(Collision other, bool canAttack)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (canAttack)
                    AudioManager.Instance.PlayerHitPlayed = true;
                if (!canAttack)
                {
                    AudioManager.Instance.PlayerHitPlayed = false;
                    AudioManager.Instance.PlayerHitSound();
                }
                
                _enemyAnimation.AttackAnimation(canAttack);
            }
        }

        public void TurnBack()
        {
            _navMeshAgent.SetDestination(FindObjectOfType<SpawnPointController>().transform.position); // temporarily
            _enemyAnimation.AttackAnimation(false);
            _navMeshAgent.speed = 1.5f;
        }
    }
}