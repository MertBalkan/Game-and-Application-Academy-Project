using System;
using System.Linq;
using AcademyProject.Combats;
using AcademyProject.Controllers;
using AcademyProject.Systems;
using UnityEngine;
using UnityEngine.UIElements;

namespace AcademyProject.UIs
{
    /// <summary>
    /// Managing InventoryUI and Inventory Slots
    /// </summary>
    public sealed class InventoryUI : MonoBehaviour
    {
        public InventorySlotUI[] inventorySlots;
        
        private void Awake()
        {
            inventorySlots = GetComponentsInChildren<InventorySlotUI>();
        }

        private void Start()
        {
            InventorySystem.Instance.OnBulletShoot += UpdateSlotItemStackCount;
        }

        /// <summary>
        /// Adds item to empty inventory slot
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToSlot(BaseItemController item)
        {
            var bulletItem = item.GetComponent<IBulletable>();
            int indexOfFirstEmptyUIObject = -1;
            var indexUI = 0;

            foreach (InventorySlotUI ISUI in inventorySlots)
            {
                if (!ISUI.isSlotFull)
                {
                    indexOfFirstEmptyUIObject = indexUI;
                    break;
                }

                indexUI++;
            }

            int indexOfSameTypeItem = -1;
            var index = 0;
            foreach (IBulletable ib in InventorySystem.Instance.ownedBulletTypes)
            {
                if (ib != null || bulletItem != null)
                {
                    if (bulletItem != null && ib != null && InventorySystem.Instance.CheckIfSameType(ib, bulletItem))
                    {
                        indexOfSameTypeItem = index;
                        break;
                    }   
                }

                index++;
            }

            if (indexOfSameTypeItem == -1)
            {
                index = indexUI;
            }
            else
            {
                index = indexOfSameTypeItem;
            }
            
            InventorySlotUI slotUI = inventorySlots[index];
            slotUI.whichObjectIHave = item.gameObject;
            slotUI.SlotImage.sprite = item.itemDataSO.itemTexture;
            slotUI.isSlotFull = true;

            if (index == indexUI && indexOfSameTypeItem == -1)
            {
                slotUI.ItemCountText.text = InventorySystem.Instance.Items[index].itemDataSO.stackCount.ToString();
            }
            else
            {
                slotUI.ItemCountText.text = InventorySystem.Instance.ownedBulletCounts[index].ToString();
            }
        }
        
        /// <summary>
        /// Removes item from full slot
        /// </summary>
        public void RemoveItemFromSlot(int index = -1)
        {
            if (index == -1)
            {
                foreach (var slotUI in inventorySlots.Reverse()) // reverse travelling
                {
                    if (slotUI.isSlotFull && slotUI.imSelected)
                    {
                        slotUI.whichObjectIHave = null;
                        slotUI.isSlotFull = false;
                        slotUI.SlotImage.sprite = null;
                        break;
                    }
                }   
            }
            else
            {
                var slotUI = inventorySlots[index];
                slotUI.whichObjectIHave = null;
                slotUI.isSlotFull = false;
                slotUI.SlotImage.sprite = null;
            }
        }

        private void OnDisable()
        {
            InventorySystem.Instance.OnBulletShoot -= UpdateSlotItemStackCount;
        }

        private void UpdateSlotItemStackCount(IBulletable bullet)
        {
            if(bullet == null) return;
            
            foreach (var slotUI in inventorySlots)
            {
                if (slotUI.isSlotFull && slotUI.imSelected)
                {
                    slotUI.ItemCountText.text = InventorySystem.Instance.ownedBulletCounts[slotUI.transform.GetSiblingIndex()].ToString();
                    break;
                }
            }
        }
    }
}