using AcademyProject.Inputs;
using AcademyProject.Movements;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private IInputService _input;
        private IMovementService _movement;

        private InventoryController _inventory;

        [SerializeField] private Transform muzzle, bullet, point;
        
        public Transform Muzzle => muzzle;
        public Transform Bullet => bullet;
        public Transform Point => point;
        
        public IInputService Input => _input;

        private void Awake()
        {
            _input = new PcInput();
            _movement = new MovementRigidBody(this, _input);
            
            _inventory = gameObject.AddComponent<InventoryController>();
            _inventory.inventoryUI = FindObjectOfType<InventoryUI>();
        }

        private void Update()
        {
            _movement.TurnAround();
            _inventory.DropItem(_input);
        }

        private void FixedUpdate()
        {
            _movement.ApplyMovement();
        }
    }
}