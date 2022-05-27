using UnityEngine;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Abstract Base Character Controller, template for other character controllers
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public abstract class BaseCharacterController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float moveSpeed = default;
        [SerializeField] private float turnSpeed = default;
        
        public float TurnSpeed { get => turnSpeed; set => value = turnSpeed; }
        public float MoveSpeed{ get => moveSpeed; set => value = moveSpeed; }
    }
}