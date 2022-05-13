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
            for (var i = 0; i < inventoryUI.slots.Length; i++)
            {
                var slot = inventoryUI.slots[i];
                
                if (input.DropItem && !InventorySystem.Instance.IsEmpty && slot.imSelected)
                {
                    inventoryUI.RemoveItemFromSlot();
                    if (!slot.isSlotFull) slot.ItemCountText.text = "x99";
                    
                    InventorySystem.Instance.RemoveItem(
                        (InventorySystem.Instance.Items[i]));
                }
            }
        }
    }
}