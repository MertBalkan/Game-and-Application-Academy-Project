using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.Systems;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public class CollectableObject : MonoBehaviour, ICollect
    {
        private InventorySystem _inventory;

        private void Awake()
        {
            _inventory = FindObjectOfType<InventorySystem>();
        }

        private void OnCollisionEnter(Collision other)
        {
            CollectOther(other);
        }

        public void CollectOther(Collision other)
        { 
            if (other.gameObject.CompareTag("Player"))
            {
                _inventory.AddItem(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}