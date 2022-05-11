using UnityEngine;

namespace AcademyProject.Inputs
{
    public class PcInput : IInputService
    {
        public float HorizontalMovement => Input.GetAxis("Horizontal");
        public float VerticalMovement => Input.GetAxis("Vertical");
        public bool DropItem => Input.GetKeyDown(KeyCode.G);
        public bool CollectItem => Input.GetKey(KeyCode.E);
        public bool[] Slots => new[]
        {
            Input.GetKeyDown(KeyCode.Alpha1),
            Input.GetKeyDown(KeyCode.Alpha2),
            Input.GetKeyDown(KeyCode.Alpha3),
            Input.GetKeyDown(KeyCode.Alpha4),
            Input.GetKeyDown(KeyCode.Alpha5),
            Input.GetKeyDown(KeyCode.Alpha6),
        };
    }
}