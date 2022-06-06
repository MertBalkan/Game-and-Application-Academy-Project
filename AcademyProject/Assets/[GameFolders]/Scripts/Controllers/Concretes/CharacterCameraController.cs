using Cinemachine;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Game Camera Controller
    /// </summary>
    public class CharacterCameraController : MonoBehaviour
    {
        [SerializeField] private float relativePositionToPlayer = 30.0f;
        [SerializeField] private float cameraSpeed;
        [SerializeField] private float  cameraScrollSpeed = 250.0f;
        [SerializeField] private float cameraRotateSpeed = 20.0f;
        
        private CinemachineVirtualCamera _cinemachine;
        private PlayerCharacterController _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
            _cinemachine = GetComponent<CinemachineVirtualCamera>();
        }

        private void Update()
        {
            if (_player == null) return;
            
            CamMovementDir(Vector3.left, _player.Input.HorizontalMovement, -1);
            CamMovementDir(Vector3.right, _player.Input.HorizontalMovement, 1);
            CamMovementDir(Vector3.forward, _player.Input.VerticalMovement, 1);
            CamMovementDir(Vector3.back, _player.Input.VerticalMovement, -1);

            MouseScrollControl();
            // CameraRotate();
        }

        private void CamMovementDir(Vector3 directionVector, float direction, float compareValue)
        {
            if (Vector3.Distance(this.transform.position, _player.transform.position) > relativePositionToPlayer &&
                direction == compareValue)
                this.transform.localPosition += directionVector * Time.deltaTime * cameraSpeed;
        }

        private void MouseScrollControl()
        {
            var camScrollVal = _player.Input.CameraScroll * cameraScrollSpeed * Time.deltaTime;
            var clampedVal = Mathf.Clamp(camScrollVal, 15, 60);
            _cinemachine.m_Lens.FieldOfView -= camScrollVal;
        }

        private void CameraRotate()
        {
            if (_player.Input.CamLeftMov)
                transform.RotateAround(_player.transform.position, Vector3.up, cameraRotateSpeed * Time.deltaTime);

            if (_player.Input.CamRightMov)
                transform.RotateAround(_player.transform.position, Vector3.up, -cameraRotateSpeed * Time.deltaTime);
        }
    }
}