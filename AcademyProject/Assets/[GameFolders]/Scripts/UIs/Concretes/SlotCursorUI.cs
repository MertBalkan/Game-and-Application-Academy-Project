using AcademyProject.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    public class SlotCursorUI : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI[] slots;
        public InventorySlotUI[] Slots => slots;
        
        private IInputService _input;

        private void Awake()
        {
            _input = new PcInput();
        }

        private void Update()
        {
            SlotControl();
        }

        private void SlotControl()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (_input.Slots[i])
                {
                    transform.position = slots[i].gameObject.transform.position + new Vector3(0, 50, 0);
                   
                    foreach (var s in slots)
                        s.imSelected = false;
                    
                    slots[i].imSelected = true;
                }
                else if(i == slots.Length) 
                    transform.position = slots[5].gameObject.transform.position + new Vector3(-65, 50, 0);
            }
        }
    }
}