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

        private bool _isWeaponPickedUp;

        private void Awake()
        {
            _input = new PcInput();
            _slotCursorUI = FindObjectOfType<SlotCursorUI>();
        }

        private void Update()
        {
            if (_isWeaponPickedUp)
            {
                var playerHand = FindObjectOfType<PlayerHand>();
                if(playerHand.Equals(null)) return;
                    
                gameObject.transform.position = playerHand.gameObject.transform.position;
            }
        }

        private void OnCollisionStay(Collision other)
        {
            CollectOther(other);
        }

        public void CollectOther(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && !InventorySystem.Instance.IsOverMaxCapacity && _input.CollectItem)
            {
                if (gameObject.GetComponent<BaseItemController>().itemDataSO
                        .isWeapon) 
                {
                    // weapon ui, add weapon
                    gameObject.SetActive(true);
                    return;
                }

                var inventoryUI = FindObjectOfType<InventoryUI>();
                if(inventoryUI == null) return;
                
                InventorySystem.Instance.AddItem(gameObject.GetComponent<BaseItemController>());
                inventoryUI.AddItemToSlot(gameObject.GetComponent<BaseItemController>(), gameObject.GetComponent<BaseItemController>().itemDataSO.stackCount);

                if (!gameObject.GetComponent<BaseItemController>().itemDataSO.isWeapon) // if item that we picked up is not a weapon
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    _isWeaponPickedUp = true;
                }
            }
        }
    }
}