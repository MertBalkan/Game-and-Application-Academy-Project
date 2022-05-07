using UnityEngine;

namespace AcademyProject.Inputs
{
    public class PcInput : IInputService
    {
        public float HorizontalMovement => Input.GetAxis("Horizontal");
        public float VerticalMovement => Input.GetAxis("Vertical");
        public bool DropItem => Input.GetKeyDown(KeyCode.G);
    }
}