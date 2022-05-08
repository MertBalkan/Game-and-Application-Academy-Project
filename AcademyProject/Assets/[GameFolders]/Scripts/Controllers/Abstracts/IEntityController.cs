using AcademyProject.Inputs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
        float TurnSpeed { get; set; }
        float MoveSpeed { get; set; }
    }
}