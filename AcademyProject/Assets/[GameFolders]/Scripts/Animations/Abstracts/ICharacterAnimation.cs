using AcademyProject.Inputs;

namespace AcademyProject.Animations
{
    public interface ICharacterAnimation
    {
        void MovementAnimation(float speed);
        void CollectAnimation();
        void SlingWeaponAnimation(float slingTime, bool readyFire);
    }   
}
