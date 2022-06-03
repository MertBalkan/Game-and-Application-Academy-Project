using System;
using AcademyProject.Controllers;
using AcademyProject.Managers;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Combats
{
    /// <summary>
    /// Only add this class to damage classes you want to.
    /// Contains data about damage.
    /// </summary>
    public class MakeDamage : MonoBehaviour, IDamage
    {
        [SerializeField] private DamageDataSO damageDataSO;

        private void Start()
        {
            Destroy(this.gameObject, 5.0f);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
               ApplyDamage(collision);
            
            SpawnEffect(collision);
        }

        public void ApplyDamage(Collision collision)
        {
            var health = collision.transform.GetComponent<CharacterHealth>();
            if(health.Equals(null)) return;
            
            try
            {
                var enemyAnimation = collision.transform.GetComponent<EnemyController>().EnemyAnimation;
                
                if(enemyAnimation.Equals(null)) return;
            
                Debug.Log(enemyAnimation);
        
                health.TakeDamage(damageDataSO.damageHitCount);
                GameManager.Instance.UpdateScore(damageDataSO.gainedPoints);
            
                if (health.IsDead)
                {
                    enemyAnimation.DieAnimation();
                    Destroy(health.gameObject, 2.0f);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void SpawnEffect(Collision collision)
        {
            if(damageDataSO.effectPrefab == null) return; // Just pass if prefab is null
            if(collision.gameObject.tag.Equals("Player")) return;
            
            var effect = Instantiate(damageDataSO.effectPrefab);

            if (collision.gameObject.Equals(effect)) Destroy(effect);
            effect.transform.position = this.transform.position + Vector3.up * 2;
        }
    }
}