using UnityEngine.AI;

namespace AcademyProject.Controllers
{
    public class ThiefCharacterController : BaseCharacterController
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _navMeshAgent.SetDestination(FindObjectOfType<PlayerCharacterController>().transform.position);
        }
    }
}