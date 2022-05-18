using UnityEngine;

namespace AcademyProject.ScriptableObjects
{
    /// <summary>
    /// This class contains data information about items
    /// </summary>
    [CreateAssetMenu(menuName = "AcademyProject/Create New Item Data")]
    public class ItemDataSO : ScriptableObject
    {
        [Header("\t\tITEM INFORMATIONS")]
        [Header("-----------------------------------------------------------")]
        [Space(35)]
        
        public string itemName;
        public Sprite itemTexture;
        public int stackCount;
        [TextArea] public string itemDescription;
        public bool isWeapon;

        // Here will be change...

        /*
        public bool isDamageable;
        public DamageDataSO damageData;
        */
    }
}
