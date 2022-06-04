using System;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class KeyController : MonoBehaviour
    {
        [SerializeField] private DoorController[] whichDoors;
        private bool _isCollected;

        public bool IsCollected
        {
            get => _isCollected;
            set => _isCollected = value;
        }
      

        private void Start()
        {
            for (int i = 0; i < whichDoors.Length; i++)
                whichDoors[i].OnKeyCollected += HandleOnKeyCollected;
            
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if(_isCollected) gameObject.SetActive(false);
        }

        private void HandleOnKeyCollected()
        {
            
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") &&
                collision.gameObject.GetComponent<PlayerCharacterController>().Input.CollectItem)
            {
                FindObjectOfType<PlayerCharacterController>().CharacterAnimation.CollectAnimation();
                
                for (int i = 0; i < whichDoors.Length; i++)
                    whichDoors[i].CollectKey();

                _isCollected = true;
                gameObject.SetActive(false);
            }                
        }
    }
}