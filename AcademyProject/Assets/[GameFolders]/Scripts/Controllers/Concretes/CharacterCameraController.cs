using UnityEngine;

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

        private PlayerCharacterController _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
        }

        private void Update()
        {
            if (_player == null) return;
            
            CamMovementDir(Vector3.left, _player.Input.HorizontalMovement, -1);
            CamMovementDir(Vector3.right, _player.Input.HorizontalMovement, 1);
            CamMovementDir(Vector3.forward, _player.Input.VerticalMovement, 1);
            CamMovementDir(Vector3.back, _player.Input.VerticalMovement, -1);

            MouseScroolControl();
        }

        private void CamMovementDir(Vector3 directionVector, float direction, float compareValue)
        {
            if (Vector3.Distance(this.transform.position, _player.transform.position) > relativePositionToPlayer &&
                direction == compareValue)
                this.transform.localPosition += directionVector * Time.deltaTime * cameraSpeed;
        }

        private void MouseScroolControl()
        {
            var transformPosition = transform.position;
            var camScrollVal = _player.Input.CameraScroll * cameraScrollSpeed * Time.deltaTime;

            transformPosition.y += camScrollVal;
            transformPosition.z += camScrollVal;
            
            transform.position = transformPosition;
        }
    }
}