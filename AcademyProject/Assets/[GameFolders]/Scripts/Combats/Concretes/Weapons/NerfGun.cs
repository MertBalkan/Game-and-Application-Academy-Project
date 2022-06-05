using UnityEngine;

namespace AcademyProject.Combats
{
    public class NerfGun : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private float timeBetweenAttacks;
       
        [SerializeField] private LayerMask enemy;
        
        [SerializeField] private Transform bullet;
        [SerializeField] private Transform spawnPoint;
        
        private bool  _isEnemyInAttackRange;
        private bool  _alreadyAttack;
        
        private Collider _targetCollider;
        
        void Update()
        {
            _isEnemyInAttackRange = Physics.CheckSphere(transform.position, attackRange,enemy);

            if (_isEnemyInAttackRange)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, enemy);
                
                foreach (var playerCollider in colliders)
                    _targetCollider = playerCollider;
                
                AttackEnemy();
            }
        }
        
        void AttackEnemy()
        {
            transform.LookAt(_targetCollider.transform);
            
            if (!_alreadyAttack)
            {
                var qut = Quaternion.Euler(spawnPoint.transform.rotation.x - 20.0f,
                    spawnPoint.transform.rotation.y, spawnPoint.transform.rotation.z);
                
                var obj = Instantiate(bullet, spawnPoint.position,  spawnPoint.transform.rotation);
                if(obj == null) return;
                
                obj.GetComponent<Rigidbody>().AddForce(transform.forward * 25f,ForceMode.Impulse);
                obj.GetComponent<Rigidbody>().AddForce(transform.up * 7f, ForceMode.Impulse);

                _alreadyAttack = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        
        void ResetAttack() => _alreadyAttack = false;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}