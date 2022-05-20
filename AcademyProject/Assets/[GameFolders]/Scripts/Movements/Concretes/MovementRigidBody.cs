using AcademyProject.Controllers;
using AcademyProject.Inputs;
using UnityEngine;

namespace AcademyProject.Movements
{
    public class MovementRigidBody : IMovementService
    {
        private IInputService _input;
        private IEntityController _entity;
        
        private Rigidbody _rigidbody;
        private Vector3 _inputVector;

        public bool CanMove => !_input.IncreaseSlingForce;

        public MovementRigidBody(IEntityController entity, IInputService input)
        {
            _entity = entity;
            _input = input;
            
            _rigidbody = _entity.transform.GetComponent<Rigidbody>();
        }
        
        void GatherInput() => _inputVector = new Vector3(_input.HorizontalMovement, 0, _input.VerticalMovement);

        public void TurnAround()
        {
            if (_inputVector == Vector3.zero) return;

            var rot = Quaternion.LookRotation(_inputVector.ToIso(), Vector3.up);
            _entity.transform.rotation = Quaternion.RotateTowards(_entity.transform.rotation, rot, _entity.TurnSpeed * Time.deltaTime);

        }

        public void ApplyMovement()
        {
            // if (CanMove)
            // {
                GatherInput();
                _rigidbody.MovePosition(_entity.transform.position + _entity.transform.forward * _inputVector.magnitude * _entity.MoveSpeed * Time.deltaTime);
            // }
        }

    } 
    
    public static class Helpers
    {
        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
        public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
    }
}