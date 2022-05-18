using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.Combats
{
    public class SlingWeapon : BaseWeaponController, IWeaponType
    {
        private float _slingTime;
        private float _slingForce = 0;
        private float _maxSlingTime = 2.0f;
        private float _maxSlingForce = 1000;

        private PlayerCharacterController _player;
        
        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
        }

        private void Update()
        {
            if (IsSlingInInventory())
                ApplyWeaponType();
        }

        public void ApplyWeaponType()
        {
            if (_player.Input.IncreaseSlingForce)
                SlingForceSpeed();
            
            SlingShot();
        }
        
        private void SlingShot()
        {
            if (_player.Input.Fire)
            {
                var clone = InstantiateBullet();
                clone.GetComponent<Rigidbody>().AddForce(clone.up * _slingForce);
                
                _player.CharacterAnimation.SlingWeaponAnimation(_slingTime, false);
                ResetSlingForce();
            }
        }

        private Transform InstantiateBullet()
        {
            return Instantiate(_player.Bullet, _player.Point.position, _player.Muzzle.rotation);
        }

        private void SlingForceSpeed()
        {
            _slingTime += Time.deltaTime;
            _slingForce += _slingTime * 5.0f;
            
            _slingTime = _slingTime >= _maxSlingTime ? _slingTime = _maxSlingTime : _slingTime ;
            _slingForce = _slingForce >= _maxSlingForce ? _slingForce = _maxSlingForce : _slingForce;

            Debug.Log("SLING TIME: " + _slingTime);
            _player.CharacterAnimation.SlingWeaponAnimation(_slingTime, true);
        }

        private void ResetSlingForce()
        {
            _slingForce = 0.0f;
            _slingTime = 0.0f;
        }

        private bool IsSlingInInventory() => isInInventory;
    }   
}