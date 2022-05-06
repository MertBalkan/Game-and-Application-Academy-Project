using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyProject.Systems
{
    /// <summary>
    /// Item system, holds current items and helps user, about adjusting items
    /// </summary>
    public class InventorySystem : MonoBehaviour
    {
        //capacity of pack
        //current items in the pack
        [SerializeField] private List<GameObject> _items;
        [SerializeField] private int maxCapacity;
        public bool IsEmpty => _items.Count == 0;
        public bool IsOverMaxCapacity => _items.Count >= maxCapacity;

        public List<GameObject> Items => _items;

        public void AddItem(GameObject item)
        {
            _items.Add(item);
        }

        public void RemoveItem(GameObject removedItem)
        {
            if (!removedItem.Equals(null))
                _items.Remove(removedItem);
        }
    }
}