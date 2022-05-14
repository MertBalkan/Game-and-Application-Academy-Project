using System.Collections.Generic;
using AcademyProject.Combats;
using AcademyProject.Inputs;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        private List<IWeaponType> _weapons;
        private IWeaponType _currentWeapon;

        public Transform namlu, mermi, nokta;
        private int _weaponIndex;
        
        private void Awake()
        {
            // _currentWeapon = new SlingWeapon(namlu, mermi, nokta);
            _weapons.Add(_currentWeapon);
            _weaponIndex++;
        }

        public void ChangeWeapon(IInputService input)
        {
            if (input.ChangeWeapon)
            {
                _weaponIndex++;
            }

            if (_weaponIndex >= 3) _weaponIndex = 0; // CHANGE HERE LATER
        }

        
    }   
}
