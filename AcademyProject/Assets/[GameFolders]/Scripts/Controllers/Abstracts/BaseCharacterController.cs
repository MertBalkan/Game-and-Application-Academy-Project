using UnityEngine;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Abstract Base Character Controller, template for other character controllers
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public abstract class BaseCharacterController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float _movespeed = default;
        [SerializeField] private float _turnspeed = default;
        
        public float TurnSpeed { get => _turnspeed; set => value = _turnspeed; }
        public float MoveSpeed{ get => _movespeed; set => value = _movespeed; }
    }
}