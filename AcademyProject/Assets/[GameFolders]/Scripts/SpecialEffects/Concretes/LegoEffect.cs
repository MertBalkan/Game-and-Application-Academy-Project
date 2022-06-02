using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.SpecialEffects
{
    public class LegoEffect : MonoBehaviour, IEffect
    {
        private void Start()
        {
            Destroy(this.gameObject, 5.0f);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                ApplyEffect(collision);
            }
        }

        public void ApplyEffect(Collision collision)
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            if(enemy == null) return;
            Debug.Log("DESTROYLANDI");
            
            Destroy(enemy); // for now
        }
    }
}