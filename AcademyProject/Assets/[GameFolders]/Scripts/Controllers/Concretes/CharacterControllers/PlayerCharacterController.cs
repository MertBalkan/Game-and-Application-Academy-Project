using AcademyProject.Inputs;
using AcademyProject.Movements;
using AcademyProject.UIs;

namespace AcademyProject.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private IInputService _input;
        private IMovementService _movement;

        private InventoryController _inventory;

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