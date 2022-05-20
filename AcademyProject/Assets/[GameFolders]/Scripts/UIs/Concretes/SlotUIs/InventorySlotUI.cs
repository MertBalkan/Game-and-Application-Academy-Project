using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AcademyProject.UIs
{
    /// <summary>
    /// Every slot in inventory
    /// </summary>
    public class InventorySlotUI : BaseSlotUI, IDragHandler, IEndDragHandler
    {
        public bool isSlotFull = false;
        public bool imSelected = false;

        private GameObject _canvas;
        
        private TextMeshProUGUI itemCountText;
        public TextMeshProUGUI ItemCountText { get { return itemCountText;} set { value = itemCountText; } }

        private Transform _mainTransform;

        protected override void Awake()
        {
            base.Awake();
            _mainTransform = transform;
            _canvas = GameObject.Find("InventoryUICanvas");
            itemCountText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = _mainTransform.position;
        }
    }
}