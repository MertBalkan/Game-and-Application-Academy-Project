using AcademyProject.Inputs;
using AcademyProject.Movements;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace AcademyProject.Controllers
{
    public class NewMovementScript : IMovementService
    {
        private IEntityController _entity;       
        private IInputService _input;
        private CharacterCameraController _cam;
        private Vector3 _inputVector;
        private Vector3 _moveDir;

        private float _turnSmoothVel;
        
        public bool CanMove => !_input.IncreaseSlingForce;

        
        public NewMovementScript(IEntityController entity,  IInputService input, CharacterCameraController cam)
        {
            _entity = entity;
            _input = input;
            _cam = cam;
        }
        
        public void TurnAround()
        { 
            if(new Vector3(_input.HorizontalMovement, 0, _input.VerticalMovement) == Vector3.zero) return;

            var rot = Quaternion.LookRotation(_moveDir.ToIso(), Vector3.up);
            _entity.transform.rotation = Quaternion.RotateTowards(_entity.transform.localRotation, rot, _entity.TurnSpeed * Time.deltaTime);

        }
        public void ApplyMovement()
        {
            if (CanMove)
            {
                float hor = _input.HorizontalMovement;
                float ver = _input.VerticalMovement;

                Vector3 dir = new Vector3(hor, 0, ver).normalized;

                if (dir.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + _cam.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDamp(_entity.transform.eulerAngles.y, targetAngle, ref _turnSmoothVel,
                        _entity.TurnSpeed);
                
                    _entity.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
                    _moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    _entity.transform.Translate(_moveDir.normalized * _entity.MoveSpeed * Time.deltaTime);

                    // var rot = Quaternion.LookRotation(new Vector3(hor, 0, ver).ToIso(), Vector3.up);
                    // _entity.transform.rotation = Quaternion.RotateTowards(_entity.transform.localRotation, rot, _entity.TurnSpeed * Time.deltaTime);

                }
            }
        }
    }
    public static class Helpers
    {
        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
        public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint(input);
    }
}