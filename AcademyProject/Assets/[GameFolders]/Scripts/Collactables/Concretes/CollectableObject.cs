using System;
using System.Collections;
using System.Collections.Generic;
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
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                // add item to inventory
            }
        }
    }
}