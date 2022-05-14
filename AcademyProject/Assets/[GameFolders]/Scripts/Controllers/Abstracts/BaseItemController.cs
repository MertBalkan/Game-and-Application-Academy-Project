using System;
using AcademyProject.Combats;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    /// <summary>
    /// Abstract Base Item Controller. 
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseItemController : MonoBehaviour
    {
        public ItemDataSO itemDataSO;
        public bool isInInventory;

        private void OnEnable()
        {
            if(itemDataSO.isWeapon) return;
            transform.SetParent(null);
        }

        private void OnDisable()
        {
            if(itemDataSO.isWeapon) return;
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