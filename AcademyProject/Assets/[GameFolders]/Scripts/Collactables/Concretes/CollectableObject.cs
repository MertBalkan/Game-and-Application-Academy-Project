using AcademyProject.Controllers;
using AcademyProject.Inputs;
using AcademyProject.Systems;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public class CollectableObject : MonoBehaviour, ICollect
    {
        private IInputService _input;
        private SlotCursorUI _slotCursorUI;

        private void Awake()
        {
            _input = new PcInput();
            _slotCursorUI = FindObjectOfType<SlotCursorUI>();
        }

        private void OnCollisionStay(Collision other)
        {
            CollectOther(other);
        }

        public void CollectOther(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && !InventorySystem.Instance.IsOverMaxCapacity && _input.CollectItem)
            {
                var inventoryUI = FindObjectOfType<InventoryUI>();
                if(inventoryUI == null) return;
                
                InventorySystem.Instance.AddItem(gameObject.GetComponent<BaseItemController>());
                
                inventoryUI.AddItemToSlot(gameObject.GetComponent<BaseItemController>());
                gameObject.SetActive(false);

                for (var index = 0; index < _slotCursorUI.Slots.Length; index++)
                {
                    var slot = _slotCursorUI.Slots[index];
                    
                    if(index == _slotCursorUI.Slots.Length - 1) return;
                    var nextSlot = _slotCursorUI.Slots[index + 1];
                    
                    if ((!nextSlot.isSlotFull) || (!slot.isSlotFull && nextSlot.isSlotFull))
                    {
                        slot.ItemCountText.text = "x" + GetComponent<BaseItemController>().itemDataSO.stackCount.ToString();
                        break;
                    }
                }
            }
        }
    }
}