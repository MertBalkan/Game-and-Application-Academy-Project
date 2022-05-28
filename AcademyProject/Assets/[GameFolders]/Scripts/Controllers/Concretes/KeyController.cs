using UnityEngine;

namespace AcademyProject.Controllers
{
    public class KeyController : MonoBehaviour
    {
        [SerializeField] private DoorController[] whichDoors;
      

        private void Start()
        {
            for (int i = 0; i < whichDoors.Length; i++)
                whichDoors[i].OnKeyCollected += HandleOnKeyCollected;
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
                
                Destroy(this.gameObject);
            }                
        }
    }
}