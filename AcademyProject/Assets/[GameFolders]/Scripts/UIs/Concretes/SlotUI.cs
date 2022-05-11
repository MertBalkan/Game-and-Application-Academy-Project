using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    }
}