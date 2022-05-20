using System;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Abstract Base Item Controller. 
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseItemController : BaseBehaviourController
    {
        private void Awake()
        {
            itemDataSO = Instantiate(itemDataSO);
            itemDataSO.stackCount = stackQuantity;
        }
        private void OnEnable()
        {
            transform.SetParent(null);
        }

        private void OnDisable()
        {
            ToThePlayerInventory();
        }
        
        private void ReAttachParent()
        {
            transform.SetParent(FindObjectOfType<PlayerHand>().transform);
        }
        
        private void ToThePlayerInventory()
        {
            if (!isInInventory || this.gameObject.activeSelf) return;
            
            this.transform.position = FindObjectOfType<PlayerHand>().transform.position;
            Invoke(nameof(ReAttachParent), 0.1f);
        }
    }
}