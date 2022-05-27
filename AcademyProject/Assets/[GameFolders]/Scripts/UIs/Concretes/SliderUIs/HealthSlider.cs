using AcademyProject.Combats;
using AcademyProject.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    public class HealthSlider : MonoBehaviour
    {
        private IEntityController _character;
        private IHealth _characterHealth;
        
        private Slider _slider;
        
        private void Awake()
        { 
            _slider = GetComponent<Slider>();
            CheckIsCharNull();
            _character = gameObject.GetComponentInParent<BaseCharacterController>();
            _characterHealth = _character.transform.gameObject.GetComponent<CharacterHealth>();
        }

        private void Update()
        {
            AdjustSlider();
        }

        private void AdjustSlider()
        {
            CheckIsCharNull();
            
            _slider.value = _characterHealth.CurrentHealth;
            
            if (_characterHealth.CurrentHealth == 0)
                _slider.value = 0;
        }

        private void CheckIsCharNull()
        {
            if(_character == null) return;
        }
    }
}