using AcademyProject.Inputs;

namespace AcademyProject.Animations
{
    public interface ICharacterAnimation
    {
        void MovementAnimation(float speed);
        void DieAnimation();
        void CollectAnimation();
        void SlingWeaponAnimation(float slingTime, bool readyFire);
        void AttackAnimation(bool attack);
    }   
}
