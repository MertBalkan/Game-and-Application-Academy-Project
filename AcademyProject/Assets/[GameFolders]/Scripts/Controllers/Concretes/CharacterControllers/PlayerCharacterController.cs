using AcademyProject.Animations;
using AcademyProject.Combats;
using AcademyProject.Inputs;
using AcademyProject.Managers;
using AcademyProject.Movements;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private IInputService _input;
        private IMovementService _movement;
        private ICharacterAnimation _animation;

        private InventoryController _inventory;

        [SerializeField] private Transform muzzle, point;
        
        public Transform Muzzle => muzzle;
        public Transform Point => point;
        
        public IInputService Input => _input;
        public ICharacterAnimation CharacterAnimation => _animation;

        private void Awake()
        {
            _input = new PcInput();
            _movement = new MovementRigidBody(this, _input);
            _animation = new PlayerAnimation(this);
            
            _inventory = gameObject.AddComponent<InventoryController>();
            _inventory.inventoryUI = FindObjectOfType<InventoryUI>();
        }

        private void Update()
        {
            if (gameObject.GetComponent<IHealth>().IsDead)
                GameManager.Instance.LoseGame(true);
            
            #region Movement
            _movement.TurnAround();
            #endregion

            #region Inventory
            _inventory.DropItem(_input);
            #endregion

            #region Animation
            _animation.MovementAnimation(_input.VerticalMovement);
            _animation.MovementAnimation(_input.HorizontalMovement);
            #endregion
        }

        private void FixedUpdate()
        {
            if(gameObject.GetComponent<IHealth>().IsDead) return;
            _movement.ApplyMovement();
        }
    }
}