using UnityEngine;

namespace AcademyProject.Controllers
{
    public class DoorController : MonoBehaviour
    {
        public event System.Action OnKeyCollected; 
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void CollectKey()
        {
            OnKeyCollected?.Invoke();
            _animator.SetTrigger("door");
        }
    }
}