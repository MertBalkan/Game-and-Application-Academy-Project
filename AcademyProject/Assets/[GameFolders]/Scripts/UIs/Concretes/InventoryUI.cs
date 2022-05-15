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
        public SlotUI[] slots;
        
        private void Awake()
        {
            slots = GetComponentsInChildren<SlotUI>();
        }

        /// <summary>
        /// Adds item to empty inventory slot
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToSlot(BaseItemController item, int stackCount)
        {
            foreach (var slotUI in slots)
            {
                if (!slotUI.isSlotFull)
                {
                    slotUI.SlotImage.sprite = item.itemDataSO.itemTexture;
                    slotUI.isSlotFull = true;
                    slotUI.ItemCountText.text = stackCount.ToString();
                    break;
                }
            }
        }
        
        /// <summary>
        /// Removes item from full slot
        /// </summary>
        public void RemoveItemFromSlot()
        {
            // if(slots[0].SlotImage.sprite.Equals(null)) return; // if first index is already empty, just return.

            foreach (var slotUI in slots.Reverse()) // reverse travelling
            {
                if (slotUI.isSlotFull && slotUI.imSelected)
                {
                    slotUI.isSlotFull = false;
                    slotUI.SlotImage.sprite = null;
                    break;
                }
            }
        }
    }
}
