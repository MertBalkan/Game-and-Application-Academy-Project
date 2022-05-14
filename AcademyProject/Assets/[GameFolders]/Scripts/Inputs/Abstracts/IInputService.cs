namespace AcademyProject.Inputs
{
    public interface IInputService
    {
        float HorizontalMovement { get; }
        float VerticalMovement { get; }
        bool DropItem { get; }
        bool CollectItem { get; }
        bool[] Slots { get; }
        bool ChangeWeapon { get; }

    }
}