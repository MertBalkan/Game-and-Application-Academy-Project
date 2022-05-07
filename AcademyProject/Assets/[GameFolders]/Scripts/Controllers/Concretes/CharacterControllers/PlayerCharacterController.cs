using AcademyProject.Inputs;
using AcademyProject.Movements;
using AcademyProject.Systems;

namespace AcademyProject.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private IInputService _input;
        private IMovementService _movement;
        
        private void Awake()
        {
            _input = new PcInput();
            _movement = new MovementRigidBody(this, _input);
        }

        private void Update()
        {
            _movement.TurnAround();
            DropItem();
        }

        private void FixedUpdate()
        {
            _movement.ApplyMovement();
        }

        private void DropItem()
        {
            if (_input.DropItem && !InventorySystem.Instance.IsEmpty)
            {
                InventorySystem.Instance.RemoveItem((InventorySystem.Instance.Items[InventorySystem.Instance.Items.Count - 1]));
            }
        }
    }
}