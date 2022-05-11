using System;
using AcademyProject.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    /// <summary>
    /// Every slot in inventory
    /// </summary>
    public class SlotUI : MonoBehaviour
    {
        public bool isSlotFull = false;
        public bool imSelected = false;
        
        private Image _slotImage;
        public Image SlotImage => _slotImage;

        private void Awake()
        {
            _slotImage = GetComponent<Image>();
        }
    }
}