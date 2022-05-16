using AcademyProject.Controllers;
using UnityEngine;

namespace AcademyProject.UIs
{
    public sealed class WeaponUI : MonoBehaviour
    {
        public WeaponSlotUI weaponSlot;
        
        public void AddWeaponToSlot(BaseWeaponController weapon)
        {
            weaponSlot.SlotImage.sprite = weapon.itemDataSO.itemTexture;
        }
    }
}