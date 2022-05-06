using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.Controllers;
using AcademyProject.Systems;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public class CollectableObject : MonoBehaviour, ICollect
    {
        private void OnCollisionEnter(Collision other)
        {
            CollectOther(other);
        }

        public void CollectOther(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && !InventorySystem.Instance.IsOverMaxCapacity)
            {
                InventorySystem.Instance.AddItem(gameObject.GetComponent<BaseItemController>());
                gameObject.SetActive(false);
            }
        }
    }
}