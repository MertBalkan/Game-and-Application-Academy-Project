using System.Linq;
using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.UIs
{
    /// <summary>
    /// Managing InventoryUI and Inventory Slots
    /// </summary>
    public sealed class InventoryUI : MonoBehaviour
    {
        [SerializeField] private SlotUI[] slots;
        
        private void Awake()
        {
            slots = GetComponentsInChildren<SlotUI>();
        }

        /// <summary>
        /// Adds item to empty inventory slot
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToSlot(BaseItemController item)
        {
            foreach (var slotUI in slots)
            {
                if (!slotUI.isSlotFull)
                {
                    slotUI.SlotImage.sprite = item.itemDataSO.itemTexture;
                    slotUI.isSlotFull = true;
                    break;
                }
            }
        }
        
        /// <summary>
        /// Removes item from full slot
        /// </summary>
        public void RemoveItemFromSlot()
        {
            if(slots[0].SlotImage.sprite.Equals(null)) return; // if first index is already empty, just return.

            foreach (var slotUI in slots.Reverse()) // reverse travelling
            {
                if (slotUI.isSlotFull)
                {
                    slotUI.isSlotFull = false;
                    slotUI.SlotImage.sprite = null;
                    break;
                }
            }
        }
    }
}
