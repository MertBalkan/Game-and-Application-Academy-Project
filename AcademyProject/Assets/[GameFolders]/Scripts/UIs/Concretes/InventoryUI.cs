using System;
using System.Linq;
using AcademyProject.Combats;
using AcademyProject.Controllers;
using AcademyProject.Systems;
using UnityEngine;

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
        public void AddItemToSlot(BaseItemController item, int stackCount)
        {
            var bulletItem = item.GetComponent<IBulletable>();
            foreach (var slotUI in inventorySlots)
            {
                if (bulletItem != null)
                {
                    if (!InventorySystem.Instance.IsSame && !slotUI.isSlotFull)
                    {
                        slotUI.whichObjectIHave = item.gameObject;
                        slotUI.SlotImage.sprite = item.itemDataSO.itemTexture;
                        slotUI.isSlotFull = true;
                        slotUI.ItemCountText.text = InventorySystem.Instance.TotalBulletCount.ToString();
                        break;
                    }
                    else if(InventorySystem.Instance.IsSame && slotUI.isSlotFull)
                    {
                        slotUI.ItemCountText.text = InventorySystem.Instance.TotalBulletCount.ToString();
                    }
                }
                else
                {
                    slotUI.whichObjectIHave = item.gameObject;
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
                    slotUI.ItemCountText.text = InventorySystem.Instance.TotalBulletCount.ToString();
                    break;
                }
            }
        }
    }
}