using System;
using System.Collections;
using System.Collections.Generic;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public abstract class BaseItemController : MonoBehaviour
    {
        [SerializeField] private ItemDataSO itemDataSO;
        public bool isInInventory;

        private void Update()
        {
            //Here will be change
            if (isInInventory)
            {
                this.transform.position = FindObjectOfType<PlayerHand>().transform.position;
            }

        }
    }
}