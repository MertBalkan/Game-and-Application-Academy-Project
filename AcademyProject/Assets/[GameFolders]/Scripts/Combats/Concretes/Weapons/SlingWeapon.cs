using System;
using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.Combats
{
    public class SlingWeapon : BaseItemController, IWeaponType
    {
        private float _slingTime;
        private float _maxSlingTime = 2.0f;
        private float _currentSlingForce = 0;
        private float _maxSlingForce = 1000;
        
        public Transform namlu, mermi, nokta;
       
        private void Update()
        {
            if (isInInventory)
            {
                ApplyWeaponType();
            }
        }

        public void ApplyWeaponType()
        {
            if (Input.GetMouseButton(0))
            {
                _slingTime += Time.deltaTime;
                _currentSlingForce += _slingTime * 5.0f;
            
                if (_slingTime >= _maxSlingTime)
                    _slingTime = _maxSlingTime;

                if (_currentSlingForce >= _maxSlingForce)
                    _currentSlingForce = _maxSlingForce;
            }
            InstantiateBullet();
        }
        
        private void InstantiateBullet()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var klon = Instantiate(mermi, nokta.position, namlu.rotation);
                klon.GetComponent<Rigidbody>().AddForce(klon.up * _currentSlingForce);
                
                _currentSlingForce = 0.0f;
                _slingTime = 0.0f;
            }
        }

        // public BaseItemController Bullet()
        // {
        //     if (InventorySystem.Instance.HasBulletInInventory())
        //     {
        //         
        //     }
        // }
    }   
}
