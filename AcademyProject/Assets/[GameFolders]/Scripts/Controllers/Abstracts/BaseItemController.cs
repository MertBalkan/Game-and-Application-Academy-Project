using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseItemController : MonoBehaviour
    {
        [SerializeField] private ItemDataSO itemDataSO;
        public bool isInInventory;
        
        private void OnEnable()
        {
            transform.SetParent(null);
        }

        private void OnDisable()
        { 
            ToThePlayerInventory();
        }

        void ReAttachParent()
        {
            transform.SetParent(FindObjectOfType<PlayerHand>().transform);
        }

        private void ToThePlayerInventory()
        {
            if (isInInventory && !this.gameObject.activeSelf)
            {
                this.transform.position = FindObjectOfType<PlayerHand>().transform.position;
                Invoke("ReAttachParent", 0.1f);
            }
        }
    }
}