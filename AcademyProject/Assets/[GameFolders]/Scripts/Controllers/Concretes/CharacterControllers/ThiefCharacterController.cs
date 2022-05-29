using AcademyProject.AIs;
using UnityEngine;
using UnityEngine.AI;

namespace AcademyProject.Controllers
{
    public class ThiefCharacterController : BaseCharacterController, IEnemyAI
    {
        private NavMeshAgent _navMeshAgent;
        private PlayerCharacterController _player;

        // public GameObject enemyObject => this.gameObject;
        
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

    }
}