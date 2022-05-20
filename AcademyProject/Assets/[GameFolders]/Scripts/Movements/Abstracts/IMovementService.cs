namespace AcademyProject.Movements
{
    public interface IMovementService
    {
        void TurnAround();
        void ApplyMovement();
        bool CanMove { get; }
    }
}