using UnityEngine;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Abstract Base Character Controller, template for other character controllers
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public abstract class BaseCharacterController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float movespeed = default;
        [SerializeField] private float turnspeed = default;
        
        public float TurnSpeed { get => turnspeed; set => value = turnspeed; }
        public float MoveSpeed{ get => movespeed; set => value = movespeed; }
    }
}