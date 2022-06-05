using System;
using AcademyProject.Controllers;
using AcademyProject.Managers;
using UnityEngine;

namespace AcademyProject.Combats
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float currentHealth;
        public bool IsDead => currentHealth <= 0.0f;
        public float CurrentHealth => currentHealth;

        public CharacterHealth(float currentHealth)
        {
            this.currentHealth = currentHealth;
        }
        
        public void TakeDamage(float damageCount)
        {
            if (IsDead) return;
            currentHealth -= damageCount;
        }
    }
}