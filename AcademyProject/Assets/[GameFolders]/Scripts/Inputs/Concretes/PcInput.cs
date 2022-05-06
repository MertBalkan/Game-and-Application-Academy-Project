using UnityEngine;

namespace AcademyProject.Inputs
{
    public class PcInput : IInputService
    {
        public bool DropItem => Input.GetKeyDown(KeyCode.G);
    }
}