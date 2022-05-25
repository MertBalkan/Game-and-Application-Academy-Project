using System.Collections;
using AcademyProject.ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements;

namespace AcademyProject.Combats
{
    /// <summary>
    /// Only add this class to damage classes you want to.
    /// Contains data about damage.
    /// </summary>
    public class MakeDamage : MonoBehaviour, IDamage
    {
        [SerializeField] private DamageDataSO damageDataSO;

        private int _helperCount = 3;

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
               ApplyDamage(collision);

            
            SpawnEffect(collision);
        }

        public void ApplyDamage(Collision collision)
        {
            var enemyHealth = collision.transform.GetComponent<CharacterHealth>();
            if(enemyHealth.Equals(null)) return;
        
            enemyHealth.TakeDamage(damageDataSO.damageHitCount);
            if(enemyHealth.IsDead) Destroy(enemyHealth.gameObject);
        }

        private void SpawnEffect(Collision collision)
        {
            _helperCount--;

            if (_helperCount <= -1) return;
            if(damageDataSO.effectPrefab == null) return; // Just pass if prefab is null
            if(collision.gameObject.tag.Equals("Player")) return;
            
            var effect = Instantiate(damageDataSO.effectPrefab);

            if (collision.gameObject.Equals(effect)) Destroy(effect);
            effect.transform.position = this.transform.position + Vector3.up * 2;
        }
    }
}