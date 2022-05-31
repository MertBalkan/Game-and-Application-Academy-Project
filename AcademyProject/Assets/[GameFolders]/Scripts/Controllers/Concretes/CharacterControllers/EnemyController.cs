using System;
using AcademyProject.AIs;
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

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerCharacterController>();
        }
        
        private void Update()
        {
            if(_player == null) return;
            _navMeshAgent.SetDestination(_player.transform.position);
        }

        private void OnDestroy()
        {
            WaveManager.Instance.EnemyDead(this);
        }
    }
}