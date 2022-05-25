using UnityEngine;

namespace AcademyProject.SpecialEffects
{
    public interface IEffect
    {
        void ApplyEffect(Collision collision);
    }
}