using System;
using System.Xml;
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

        private bool _hasEnemyWeapon;

        private void Awake()
        {
            _hasEnemyWeapon = gameObject.GetComponent<EnemyWeapon>() != null;
        }

        private void Start()
        {
            if(!_hasEnemyWeapon)
                Destroy(this.gameObject, 5.0f);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
               ApplyDamage(collision);

            SpawnEffect(collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player") && _hasEnemyWeapon)
            {
                other.GetComponent<IHealth>().TakeDamage(5);
            }
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