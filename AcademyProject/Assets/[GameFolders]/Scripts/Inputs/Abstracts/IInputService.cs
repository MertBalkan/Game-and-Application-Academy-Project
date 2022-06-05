namespace AcademyProject.Inputs
{
    public interface IInputService
    {
        #region Movement Inputs

        float HorizontalMovement { get; }
        float VerticalMovement { get; }

        #endregion

        #region Inventory UI Inputs

        bool[] Slots { get; }

        #endregion

        #region Item Inputs

        bool DropItem { get; }
        bool CollectItem { get; }

        #endregion

        #region Weapon Inputs

        bool Fire { get; }
        bool IncreaseSlingForce { get; }

        #endregion

        #region Camera Inputs

        float CameraScroll { get; }
        bool CamLeftMov { get; }
        bool CamRightMov { get; }
        
        #endregion

        #region Level Inputs

        bool ResetLevel { get; }

        #endregion
    }
}