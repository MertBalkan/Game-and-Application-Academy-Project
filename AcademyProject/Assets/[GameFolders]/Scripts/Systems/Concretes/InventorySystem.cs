using System.Collections.Generic;
using AcademyProject.Combats;
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
        [SerializeField] private List<BaseWeaponController> weapons;

        private int _totalItems;
        
        /// <summary>
        /// Is inventory empty?
        /// </summary>
        public bool IsEmpty => items.Count == 0;
        
        /// <summary>
        /// For checking max capacity.
        /// </summary>
        public bool IsOverMaxCapacity => _totalItems >= maxCapacity;
        
        public List<BaseItemController> Items => items;

        private void Awake()
        {
            ApplySingleton(this);

            for (int i = 0; i < maxCapacity; i++)
            {
                items.Add(null);
            }
        }
        
        /// <summary>
        /// This function adds items to inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(BaseItemController item)
        {
            foreach (var i in items)
            {
                if (i == null)
                {
                    var index = items.IndexOf(i);
                   
                    items[index] = item;
                    item.isInInventory = true;
                    
                    _totalItems++;
                    break;
                }
            }
        }

        /// <summary>
        /// Removing items from inventory.
        /// </summary>
        /// <param name="removedItem"></param>
        public void RemoveItem(BaseItemController removedItem)
        {
            var indexOf = items.IndexOf(removedItem);
            if (items[indexOf] == null) return;
            
            items[indexOf] = null;

            removedItem.isInInventory = false;
            removedItem.gameObject.SetActive(true);
            
            _totalItems--;
        }

        public void AddWeapon(BaseWeaponController weapon)
        {
            weapons.Add(weapon);
            weapon.isInInventory = true;
        }

        // public bool HasBulletInInventory()
        // {
        //     foreach (var bullet in items)
        //     {
        //         if (!bullet.GetComponent<IBulletable>().Equals(null))
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        //
        // public BaseItemController Bullet()
        // {
        //     if (HasBulletInInventory())
        //     {
        //         
        //     }
        // }
    }
}