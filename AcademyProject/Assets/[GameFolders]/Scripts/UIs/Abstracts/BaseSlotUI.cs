using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    public class BaseSlotUI : MonoBehaviour
    {
        private Image _slotImage;
        public Image SlotImage => _slotImage;

        protected virtual void Awake()
        {
            _slotImage = GetComponent<Image>();
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