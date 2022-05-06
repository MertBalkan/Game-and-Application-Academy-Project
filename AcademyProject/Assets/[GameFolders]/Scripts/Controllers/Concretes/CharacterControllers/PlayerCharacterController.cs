using System;
using AcademyProject.Controllers;
using AcademyProject.Inputs;
using AcademyProject.Systems;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private IInputService _input;
        
        private void Awake()
        {
            _input = new PcInput();
        }

        private void Update()
        {
            if (_input.DropItem && !InventorySystem.Instance.IsEmpty)
            {
                InventorySystem.Instance.RemoveItem((InventorySystem.Instance.Items[InventorySystem.Instance.Items.Count - 1]));
            }
        }
    }
}