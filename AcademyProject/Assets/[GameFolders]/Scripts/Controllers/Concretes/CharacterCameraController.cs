using UnityEngine;

namespace AcademyProject.Controllers
{
    public class CharacterCameraController : MonoBehaviour
    {
        [SerializeField] private float relativePositionToPlayer = 30.0f;
        [SerializeField] private float cameraSpeed;
        
        private PlayerCharacterController _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
        }

        private void Update()
        {
            CamMovementDir(Vector3.left, _player.Input.HorizontalMovement, -1);
            CamMovementDir(Vector3.right, _player.Input.HorizontalMovement, 1);
            CamMovementDir(Vector3.forward, _player.Input.VerticalMovement, 1);
            CamMovementDir(Vector3.back, _player.Input.VerticalMovement, -1);
        }

        private void CamMovementDir(Vector3 directionVector, float direction, float compareValue)
        {
            if (Vector3.Distance(this.transform.position, _player.transform.position) > relativePositionToPlayer && direction == compareValue)
                this.transform.localPosition += directionVector * Time.deltaTime * cameraSpeed;
        }
    }   
}
