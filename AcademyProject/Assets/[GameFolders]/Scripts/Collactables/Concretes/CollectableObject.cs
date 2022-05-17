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

        private bool _isWeaponPicked = false;

        private void Awake()
        {
            _input = new PcInput();
        }

        private void Update()
        {
            if (_isWeaponPicked)
            {
                var playerHand = FindObjectOfType<PlayerHand>();
                if(playerHand.Equals(null)) return;

                transform.position = playerHand.transform.position;
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
                var item = gameObject.GetComponent<BaseItemController>();
                var weapon = gameObject.GetComponent<BaseWeaponController>();

                if (weapon == null) // Is weapon collected?
                    GrabItem(item, FindObjectOfType<InventoryUI>());
                else
                    GrabWeapon(weapon, FindObjectOfType<WeaponUI>());
            }
        }
        
        private void GrabItem(BaseItemController item, InventoryUI inventoryUI)
        {
            if(inventoryUI == null) return;

            InventorySystem.Instance.AddItem(item);
            inventoryUI.AddItemToSlot(item, item.itemDataSO.stackCount);
            gameObject.SetActive(false);   
        }

        private void GrabWeapon(BaseWeaponController weapon, WeaponUI weaponUI)
        {
            if(weaponUI == null) return;
            
            weapon.GetComponent<BoxCollider>().isTrigger = true; // temporarily
            
            InventorySystem.Instance.AddWeapon(weapon);
            weaponUI.AddWeaponToSlot(weapon);
            _isWeaponPicked = true;
            
        }
        
    }
}