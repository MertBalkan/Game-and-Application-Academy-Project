using AcademyProject.Controllers;
using AcademyProject.Managers;
using AcademyProject.Systems;
using AcademyProject.UIs;
using UnityEngine;

namespace AcademyProject.Combats
{
    public class SlingWeapon : BaseWeaponController, IWeaponType
    {
        [SerializeField] private LayerMask ground;
        private float _slingTime;
        private float _slingForce = 0;
        private float _maxSlingTime = 2.0f;
        private float _maxSlingForce = 1000;

        private PlayerCharacterController _player;
        private Quaternion _lookRot;
        private InventoryUI _inventoryUI;
        
        private bool IsSlingInInventory() => isInInventory;
        public float SlingForce => _slingForce;
        
        private void Awake()
        {
            _inventoryUI = FindObjectOfType<InventoryUI>();
            _player = FindObjectOfType<PlayerCharacterController>();
        }

        private void Update()
        {
            if(_player.GetComponent<IHealth>().IsDead) return;
            if(IsSlingInInventory())
                ApplyWeaponType();
        }

        public void ApplyWeaponType()
        {
            foreach (var slot in _inventoryUI.inventorySlots)
            {
                if (_player.Input.IncreaseSlingForce && slot.isSlotFull && slot.whichObjectIHave.GetComponent<IBulletable>() != null && slot.imSelected)
                {
                    AudioManager.Instance.SlingSound();
                    SlingForceSpeed();
                    PlayerPointLook();
                }
            }
            SlingShot();
        }

        private void PlayerPointLook()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5000, ground))
            {
                if(hit.collider.gameObject.Equals(_player.gameObject)) return;
                // if(hit.collider.gameObject.GetComponent<EnemyController>()) return;
                
                Vector3 pos = (hit.point - _player.transform.position).normalized;
                _lookRot = Quaternion.LookRotation(pos);
                _lookRot.x = 0;
                _lookRot.z = Mathf.Clamp(_lookRot.z, -0.1f, 0.1f);
                _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, _lookRot, 1000 * Time.deltaTime);
            }
        }
        private void SlingShot()
        {
            foreach (var slot in _inventoryUI.inventorySlots)       
            {
                if (slot.imSelected && slot.isSlotFull && slot.whichObjectIHave != null)
                {
                    if (_player.Input.Fire && InventorySystem.Instance.ownedBulletCounts[slot.transform.GetSiblingIndex()] > 0)
                    {
                        var bulletObject = slot.whichObjectIHave.GetComponent<IBulletable>().BulletDataSO.bullet.transform;
                        if(bulletObject == null) return;
                        
                        var clone = InstantiateBullet(bulletObject);
                        clone.SetParent(null);
                        clone.transform.SetPositionAndRotation(_player.Muzzle.position, clone.transform.rotation);
                        clone.gameObject.SetActive(true);
                        clone.GetComponent<Rigidbody>().AddForce(clone.up * _slingForce);
                
                        _player.CharacterAnimation.SlingWeaponAnimation(_slingTime, false);
                        ResetSlingForce();

                        AudioManager.Instance.SlingShotSound();
                        CursorManager.Instance.SetNormalCursor();
                        InventorySystem.Instance.DecreaseBulletCount(slot.whichObjectIHave.GetComponent<IBulletable>());
                    }
                }
            }
        }
        private Transform InstantiateBullet(Transform bullet) => Instantiate(bullet, _player.Point.position, _player.Muzzle.rotation);

        private void SlingForceSpeed()
        {
            var inventoryUI = FindObjectOfType<InventoryUI>();

            foreach (var slots in inventoryUI.inventorySlots)
            {
                if (slots.imSelected && slots.isSlotFull)
                {
                    if (InventorySystem.Instance.HasBulletInInventory)
                    {
                        SlingLogic();
                        CursorManager.Instance.SetFireCursor();
                        _player.CharacterAnimation.SlingWeaponAnimation(_slingTime, true);
                    }
                }
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