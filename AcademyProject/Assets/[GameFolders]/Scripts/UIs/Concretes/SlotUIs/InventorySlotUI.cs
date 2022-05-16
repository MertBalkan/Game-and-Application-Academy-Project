using UnityEngine.UI;
using TMPro;

namespace AcademyProject.UIs
{
    /// <summary>
    /// Every slot in inventory
    /// </summary>
    public class InventorySlotUI : BaseSlotUI
    {
        public bool isSlotFull = false;
        public bool imSelected = false;
        
        private TextMeshProUGUI itemCountText;
        public TextMeshProUGUI ItemCountText { get { return itemCountText;} set { value = itemCountText; } }


        protected override void Awake()
        {
            base.Awake();
            itemCountText = GetComponentInChildren<TextMeshProUGUI>();
        } 

    }
}