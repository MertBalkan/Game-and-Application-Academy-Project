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
            if (input.DropItem && !InventorySystem.Instance.IsEmpty)
            {
                inventoryUI.RemoveItemFromSlot();
                InventorySystem.Instance.RemoveItem((InventorySystem.Instance.Items[InventorySystem.Instance.Items.Count - 1]));
            }
        }
    }
}