using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyProject.Collectables
{
    public class CollectObject : MonoBehaviour, ICollect
    {
        private void OnTriggerEnter(Collider other)
        {
            CollectOther(other);
        }

        public void CollectOther(Collider other)
        { 
            if (other.gameObject.CompareTag("Item"))
            {
                Destroy(other);
                // add item to inventory
            }
        }
    }
}