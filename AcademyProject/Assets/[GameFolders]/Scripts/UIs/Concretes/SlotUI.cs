using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace AcademyProject.UIs
{
    /// <summary>
    /// Every slot in inventory
    /// </summary>
    public class SlotUI : MonoBehaviour
    {
        public bool isSlotFull = false;
        public bool imSelected = false;
        
        private TextMeshProUGUI itemCountText;
        public TextMeshProUGUI ItemCountText => itemCountText;

        private Image _slotImage;
        public Image SlotImage => _slotImage;

        private void Awake()
        {
            _slotImage = GetComponent<Image>();
            itemCountText = GetComponentInChildren<TextMeshProUGUI>();
        } 

        /// <summary>
        /// Text about item description.
        /// </summary>
        // public void ShowItemDescription()
        // {
        //     Vector3 mousePos = Input.mousePosition;
        //     itemCountText.transform.position = mousePos; //+ new Vector3(-0.09f, -0.09f, 0.0f);
        // }
    }
}