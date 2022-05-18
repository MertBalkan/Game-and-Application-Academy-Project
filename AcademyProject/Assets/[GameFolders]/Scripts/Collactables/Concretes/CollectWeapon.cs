using System;
using AcademyProject.Controllers;
using AcademyProject.Inputs;
using AcademyProject.Systems;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public class CollectWeapon : MonoBehaviour, ICollect
    {
        private bool _isWeaponPicked = false;   
        public IInputService PlayerInput { get; set; }

        private void Awake()
        {
            PlayerInput = new PcInput();
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

        private void OnCollisionStay(Collision collisionInfo)
        {
            CollectOther(collisionInfo);
        }

        public void CollectOther(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && PlayerInput.CollectItem)
            {
                var weapon = gameObject.GetComponent<BaseWeaponController>();
                GrabWeapon(weapon, FindObjectOfType<WeaponUI>());
            }
        }
        
        private void GrabWeapon(BaseWeaponController weapon, WeaponUI weaponUI)
        {
            if(weaponUI == null) return;
            
            FindObjectOfType<PlayerCharacterController>().CharacterAnimation.CollectAnimation();
            weapon.GetComponent<BoxCollider>().isTrigger = true; // temporarily
            InventorySystem.Instance.AddWeapon(weapon);
            weaponUI.AddWeaponToSlot(weapon);
            _isWeaponPicked = true;
        }
    }
}
