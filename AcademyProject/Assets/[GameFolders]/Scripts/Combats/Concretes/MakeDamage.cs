using System;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Combats
{
    /// <summary>
    /// Only add this class to damage classes you want to.
    /// Contains data about damage.
    /// </summary>
    public class MakeDamage : MonoBehaviour
    {
        [SerializeField] private DamageDataSO damageDataSO;

        private void OnCollisionEnter(Collision collision)
        {
            // I'LL REFACTOR HERE LATER!!!
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                var enemyHealth = collision.transform.GetComponent<CharacterHealth>();
                if(enemyHealth.Equals(null)) return;
                
                enemyHealth.TakeDamage(damageDataSO.damageHitCount);
                Debug.Log(enemyHealth.CurrentHealth);
            }
        }
    }
}