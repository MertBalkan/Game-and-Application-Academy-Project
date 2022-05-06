using UnityEngine;

namespace AcademyProject.Combats
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        private float _currentHealth;
        public bool IsDead => _currentHealth <= 0.0f;
        public float CurrentHealth => _currentHealth;

        public CharacterHealth(float currentHealth)
        {
            _currentHealth = currentHealth;
        }
        public void TakeDamage(float damageCount)
        {
            if(IsDead) return;
            _currentHealth -= damageCount;
        }
    }
}