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
        private bool _isSame;
        public bool IsSame => _isSame;
        public event System.Action<IBulletable> OnBulletShoot;


        #region BULLET LOGIC VARIABLES

        
        //-------------------------------------BULLET LOGIC-------------------------------------
        private int _totalBulletCount;

        public int TotalBulletCount { get { return _totalBulletCount;} set { _totalBulletCount = value; } }
        public bool HasBulletInInventory => _totalBulletCount > 0;
        private int _beforeTotalCount;

        private Transform _bullet;
        public Transform Bullet => _bullet;

        public int BeforeTotalCount
        {
            get { return _beforeTotalCount;}
            set { _beforeTotalCount = value; }
        }
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

        private void Update()
        {
            Debug.Log("TOTAL BULLET COUNT: " + _totalBulletCount);
        }   
        
        /// <summary>
        /// Initializing Items
        /// </summary>
        private void InitializeItems()
        {
            for (int i = 0; i < maxCapacity; i++)
                items.Add(null);
        }

        /// <summary>
        /// This function adds items to inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(BaseItemController item)
        {
            _isSame = false;
            Debug.Log("item: " + item.GetType());

            foreach (var i in items)
            {
                if (i != null )
                    if(i.GetType() == item.GetType())
                        _isSame = true;
            }
            
            foreach (var i in items)
            {
                if (i == null && !_isSame)
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

            removedItem.isDropped = true;
            removedItem.isInInventory = false;
            removedItem.gameObject.SetActive(true);
            
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
        /// Increases bullet count
        /// </summary>
        public void UpdateBulletCount(IBulletable item)
        {
            if(item == null) return;
            
            if (!item.IsDropped)
            {
                _totalBulletCount += item.AmmoCount();
                _bullet = item.ItemObject.transform;
            }
            else
            {
                _totalBulletCount += _beforeTotalCount;
            }
        }

        public void DecreaseBulletCount()
        {
            _totalBulletCount--;
            
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] != null)
                {
                    var bullet = items[i].GetComponent<IBulletable>();
                    bullet.ItemDataSO.stackCount = _totalBulletCount;
                    OnBulletShoot?.Invoke(bullet);
                }
            }
        }
    }
}