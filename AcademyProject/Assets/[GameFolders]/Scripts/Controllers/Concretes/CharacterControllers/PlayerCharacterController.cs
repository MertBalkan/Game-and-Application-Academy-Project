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
        private InventorySystem _inventory;
        
        private void Awake()
        {
            _input = new PcInput();
            _inventory = GetComponent<InventorySystem>();
        }

        private void Update()
        {
            if (_input.DropItem && !_inventory.IsEmpty)
            {
                _inventory.RemoveItem((_inventory.Items[_inventory.Items.Count - 1]));
            }
        }
    }
}