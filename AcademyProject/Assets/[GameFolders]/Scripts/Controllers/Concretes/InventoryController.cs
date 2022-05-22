using AcademyProject.Combats;
using AcademyProject.Inputs;
using AcademyProject.Systems;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Includes some inventory control function(s)
    /// </summary>
    public class InventoryController : MonoBehaviour
    {
        public InventoryUI inventoryUI;
        
        public void DropItem(IInputService input)
        {
            for (var i = 0; i < inventoryUI.inventorySlots.Length; i++)
            {
                var slot = inventoryUI.inventorySlots[i];
                
                if (input.DropItem && !InventorySystem.Instance.IsEmpty && slot.imSelected)
                {
                    inventoryUI.RemoveItemFromSlot();
                    if (!slot.isSlotFull) slot.ItemCountText.text = "x99";

                    InventorySystem.Instance.BeforeTotalCount = InventorySystem.Instance.TotalBulletCount;
                    InventorySystem.Instance.TotalBulletCount = 0;
                    
                    InventorySystem.Instance.UpdateBulletCount(null);
                    InventorySystem.Instance.RemoveItem((InventorySystem.Instance.Items[i]));
                }
            }
        }
    }
}