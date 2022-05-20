using AcademyProject.Controllers;
using AcademyProject.Systems;
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
        private Quaternion qtO;
        
        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
        }

        private void Update()
        {
            if(IsSlingInInventory())
                ApplyWeaponType();
        }

        public void ApplyWeaponType()
        {
            if (_player.Input.IncreaseSlingForce)
            {
                SlingForceSpeed();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    Vector3 pos = (hit.point - _player.transform.position).normalized;
                    qtO = Quaternion.LookRotation(pos);
                     qtO.x = 0;
                    _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, qtO, 600 * Time.deltaTime);
                }
            }
            
            SlingShot();
        }
        
        private void SlingShot()
        {
            if (_player.Input.Fire && InventorySystem.Instance.HasBulletInInventory)
            {
                var clone = InstantiateBullet();
                clone.SetParent(null);
                clone.gameObject.SetActive(true);
                clone.GetComponent<Rigidbody>().AddForce(clone.up * _slingForce);
                
                _player.CharacterAnimation.SlingWeaponAnimation(_slingTime, false);
                ResetSlingForce();

                InventorySystem.Instance.DecreaseBulletCount();
            }
        }

        private Transform InstantiateBullet() => Instantiate(InventorySystem.Instance.Bullet, _player.Point.position, _player.Muzzle.rotation);
        
        private bool IsSlingInInventory() => isInInventory;

        private void SlingForceSpeed()
        {
            if (InventorySystem.Instance.HasBulletInInventory)
            {
                SlingLogic();
                _player.CharacterAnimation.SlingWeaponAnimation(_slingTime, true);
            }
        }

        private void ResetSlingForce()
        {
            _slingForce = 0.0f;
            _slingTime = 0.0f;
        }

        private void SlingLogic()
        {
            _slingTime += Time.deltaTime;
            _slingForce += _slingTime * 5.0f;
            
            _slingTime = _slingTime >= _maxSlingTime ? _slingTime = _maxSlingTime : _slingTime ;
            _slingForce = _slingForce >= _maxSlingForce ? _slingForce = _maxSlingForce : _slingForce;
        }
    }   
}