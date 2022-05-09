using System;
using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    public class SlotUI : MonoBehaviour
    {
        public bool isSlotFull = false;
        private Image _slotImage;
        public Image SlotImage => _slotImage;

        private void Awake()
        {
            _slotImage = GetComponent<Image>();
        }
    }
}