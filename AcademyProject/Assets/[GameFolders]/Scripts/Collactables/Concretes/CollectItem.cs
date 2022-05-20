using AcademyProject.Combats;
using AcademyProject.Controllers;
using AcademyProject.Inputs;
using AcademyProject.Systems;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public class CollectItem : MonoBehaviour, ICollect
    {
        public IInputService PlayerInput { get; set; }

        private void Awake()
        {
            PlayerInput = new PcInput();
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            CollectOther(collisionInfo);
        }

        public void CollectOther(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && PlayerInput.CollectItem && !InventorySystem.Instance.IsOverMaxCapacity)
            {
                var item = gameObject.GetComponent<BaseItemController>();
                GrabItem(item, FindObjectOfType<InventoryUI>());
            }
        }

        private void GrabItem(BaseItemController item, InventoryUI inventoryUI)
        {
            if(inventoryUI == null) return;
            
            FindObjectOfType<PlayerCharacterController>().CharacterAnimation.CollectAnimation();
            
            InventorySystem.Instance.AddItem(item);
            InventorySystem.Instance.UpdateBulletCount(item.GetComponent<IBulletable>());
            inventoryUI.AddItemToSlot(item, item.itemDataSO.stackCount);
            
            gameObject.SetActive(false);   
        }
    }
}