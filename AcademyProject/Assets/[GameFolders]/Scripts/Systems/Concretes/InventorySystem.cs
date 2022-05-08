using System.Collections.Generic;
using AcademyProject.Controllers;
using AcademyProject.Managers;
using UnityEngine;

namespace AcademyProject.Systems
{
    /// <summary>
    /// Item system, holds current items and helps user, about adjusting items.
    /// </summary>
    public class InventorySystem : SingletonMonoBehaviour<InventorySystem>
    {
        [Header("\t\tINVENTORY SYSTEM")]
        [Header("-----------------------------------------------------------")]
        [Space(35)]
        [SerializeField] private int maxCapacity;
        [SerializeField] private List<BaseItemController> items;
        [SerializeField] private PlayerCharacterController player;
        
        /// <summary>
        /// Is inventory empty?
        /// </summary>
        public bool IsEmpty => items.Count == 0;
        
        /// <summary>
        /// For checking max capacity.
        /// </summary>
        public bool IsOverMaxCapacity => items.Count >= maxCapacity;

        public List<BaseItemController> Items => items;

        private void Awake()
        {
            ApplySingleton(this);
        }

        /// <summary>
        /// This function adds items to inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(BaseItemController item)
        {
            if (!item.Equals(null))
            {
                items.Add(item);
                item.isInInventory = true;
            }
        }

        /// <summary>
        /// Removing items from inventory.
        /// </summary>
        /// <param name="removedItem"></param>
        public void RemoveItem(BaseItemController removedItem)
        {
            if (!removedItem.Equals(null))
            {
                items.Remove(removedItem);
                removedItem.isInInventory = false;
                
                removedItem.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Text about item description.
        /// </summary>
        public void ShowItemDescription()
        {
            
        }
        
    }
}