using System;
using System.Collections.Generic;
using AcademyProject.Combats;
using AcademyProject.Controllers;
using AcademyProject.Managers;
using AcademyProject.UIs;
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
        private bool _isSame;
        public bool IsSame => _isSame;
        public event System.Action<IBulletable> OnBulletShoot;


        #region BULLET LOGIC VARIABLES

        
        //-------------------------------------BULLET LOGIC-------------------------------------
        public List<int> ownedBulletCounts;
        public List<IBulletable> ownedBulletTypes;

        // public Dictionary<List<int>, List<IBulletable>> bulletDic = new Dictionary<List<int>, List<IBulletable>>();

        public int TotalBulletCount { get
        {
            int totalCount = 0;
            
            foreach (int i in ownedBulletCounts)
            {
                totalCount += i;
            }

            return totalCount;
        }}
        
        public bool HasBulletInInventory => TotalBulletCount > 0;
        private int _beforeTotalCount;

        //-------------------------------------BULLET LOGIC-------------------------------------
        #endregion
        
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
            InitializeItems();
        } 
        
        /// <summary>
        /// Initializing Items
        /// </summary>
        private void InitializeItems()
        {
            ownedBulletTypes = new List<IBulletable>();
            ownedBulletCounts = new List<int>();
            for (int i = 0; i < maxCapacity; i++)
            {
                items.Add(null);
                ownedBulletTypes.Add(null);
                ownedBulletCounts.Add(0);   
            }
        }

        /// <summary>
        /// This function adds items to inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(BaseItemController item)
        {
            _isSame = false;

            foreach (var i in items)
            {
                if (i != null && i.GetComponent<IBulletable>() != null)
                    if(CheckIfSameType(i, item))
                        _isSame = true;
            }
            
            foreach (var i in items)
            {
                if (i == null && !_isSame)
                {
                    var index = items.IndexOf(i);
                
                    items[index] = item;
                    item.isInInventory = true;

                    try
                    {
                        ownedBulletTypes[index] = (IBulletable)item;
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message + "Type isn't a bullet");
                    }

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

            removedItem.isDropped = true;
            removedItem.isInInventory = false;

            if(removedItem.GetComponent<IBulletable>() != null)
                removedItem.itemDataSO.stackCount = ownedBulletCounts[indexOf];
            
            ownedBulletCounts[indexOf] = 0;
            ownedBulletTypes[indexOf] = null;

            Debug.Log("removedItem.itemDataSO.stackCount: " + removedItem.itemDataSO.stackCount);
            if (removedItem.itemDataSO.stackCount == 0)
            {
                Destroy(removedItem.gameObject);
                FindObjectOfType<InventoryUI>().RemoveItemFromSlot(indexOf);
            }
            else
            {
                removedItem.gameObject.SetActive(true);
            }
            _totalItems--;
        }
        
        /// <summary>
        /// Adds weapon to weapon list
        /// </summary>
        /// <param name="weapon"></param>
        public void AddWeapon(BaseWeaponController weapon)
        {
            weapons.Add(weapon);
            weapon.isInInventory = true;
        }
    
        /// <summary>
        /// Updates bullet count
        /// </summary>
        public void UpdateBulletCount(IBulletable item)
        {
            if(item == null) return;

            int indexOfSameTypeItem = -1;

            var index = 0;
            foreach (IBulletable ib in ownedBulletTypes)
            {
                if (ib != null)
                {
                    if (CheckIfSameType(ib, item))
                        indexOfSameTypeItem = index;
                }
                index++;
            }
            
            if (indexOfSameTypeItem != -1)
            {
                ownedBulletCounts[indexOfSameTypeItem] += item.AmmoCount();
            }
            else
            {
                int firstEmpty = ownedBulletTypes.IndexOf(null);

                if (firstEmpty != -1)
                {
                    ownedBulletTypes[firstEmpty] = item;
                    ownedBulletCounts[firstEmpty] = item.AmmoCount();
                }
            }
            item.BulletDataSO.TotalBulletCount += item.AmmoCount();
            
            if (!item.IsDropped)
                item.BulletDataSO.TotalBulletCount += item.AmmoCount();
        }
        
        /// <summary>
        /// Decreases bullet count
        /// </summary>
        public void DecreaseBulletCount(IBulletable shotItem)
        {
            if (shotItem != null)
            {
                int indexOfSameTypeItem = -1;
                var index = 0;
                foreach (IBulletable bulletable in ownedBulletTypes)
                {
                    if (bulletable != null)
                    {
                        if (CheckIfSameType(bulletable, shotItem))
                        {
                            indexOfSameTypeItem = index;
                            break;
                        }   
                    }
                    index++;
                }

                if (indexOfSameTypeItem  != -1)
                {
                    ownedBulletCounts[indexOfSameTypeItem]--;
                    OnBulletShoot?.Invoke(shotItem);

                    if (ownedBulletCounts[indexOfSameTypeItem] == 0)
                    {
                        RemoveItem((BaseItemController)ownedBulletTypes[indexOfSameTypeItem]);
                    }
                }   
            }
        }
        
        public bool CheckIfSameType(object a, object b)
        {
            if (a.GetType() == b.GetType()) return true;
            return false;   
        }
    }
}