using UnityEngine.AI;

namespace AcademyProject.Controllers
{
    public class ThiefCharacterController : BaseCharacterController
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
    }
}