using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.Managers;
using UnityEngine;

namespace AcademyProject.Systems
{
    /// <summary>
    /// Item system, holds current items and helps user, about adjusting items.
    /// </summary>
    public class InventorySystem : SingletonMonoBehaviour<InventorySystem>
    {
        [SerializeField] private int maxCapacity;
        [SerializeField] private List<GameObject> _items;
        
        /// <summary>
        /// Is inventory empty?
        /// </summary>
        public bool IsEmpty => _items.Count == 0;
        
        /// <summary>
        /// For checking max capacity.
        /// </summary>
        public bool IsOverMaxCapacity => _items.Count >= maxCapacity;

        public List<GameObject> Items => _items;

        private void Awake()
        {
            ApplySingleton(this);
        }

        /// <summary>
        /// This function adds items to inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(GameObject item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Removing items from inventory.
        /// </summary>
        /// <param name="removedItem"></param>
        public void RemoveItem(GameObject removedItem)
        {
            if (!removedItem.Equals(null))
                _items.Remove(removedItem);
        }
    }
}