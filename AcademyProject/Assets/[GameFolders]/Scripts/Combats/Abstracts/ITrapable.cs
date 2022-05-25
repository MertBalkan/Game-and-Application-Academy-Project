using AcademyProject.SpecialEffects;

namespace AcademyProject.Combats
{
    public interface ITrapable
    {
        void TrapEffect();
        bool IsTrapActive { get; }
    }
}