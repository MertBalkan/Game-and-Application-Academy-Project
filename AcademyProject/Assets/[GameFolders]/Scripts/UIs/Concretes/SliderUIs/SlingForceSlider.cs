using AcademyProject.Combats;
using UnityEngine;
using UnityEngine.UI;

namespace AcademyProject.UIs
{
    public class SlingForceSlider : MonoBehaviour
    {
        private SlingWeapon _slingWeapon;
        private Slider _slider;
        
        private void Awake()
        { 
            _slingWeapon = FindObjectOfType<SlingWeapon>();
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {
            AdjustSlider();
        }

        private void AdjustSlider()
        {
            _slider.value = _slingWeapon.SlingForce;
            
            if (_slingWeapon.SlingForce == 0)
                _slider.value = 0;
        }
    }   
}