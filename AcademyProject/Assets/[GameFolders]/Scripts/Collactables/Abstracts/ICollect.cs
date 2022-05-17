using AcademyProject.Inputs;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public interface ICollect
    {
        void CollectOther(Collision other);
        IInputService PlayerInput { get; set; }
    }
}