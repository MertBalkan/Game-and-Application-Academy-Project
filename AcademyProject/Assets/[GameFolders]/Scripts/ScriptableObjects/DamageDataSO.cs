using UnityEngine;

namespace AcademyProject.ScriptableObjects
{   
    /// <summary>
    /// This class contains damage information about items
    /// </summary>
    [CreateAssetMenu(menuName = "AcademyProject/Create New Damage Data")]
    public class DamageDataSO : ScriptableObject
    {
        [Header("\t\tDAMAGE INFORMATIONS")]
        [Header("-----------------------------------------------------------")]
        [Space(35)]

        public float damageHitCount;
        public int gainedPoints;
        //public DamageType damageType;
    }

    // public enum DamageType
    // {
    //     MeleeDamage,
    //     TrapDamage
    // }
}