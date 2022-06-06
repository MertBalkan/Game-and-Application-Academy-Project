using UnityEngine;

namespace AcademyProject.ScriptableObjects
{  
    /// <summary>
    /// This class contains bullet information about bulletable objects
    /// </summary>
    [CreateAssetMenu(menuName = "AcademyProject/Create New Bullet Data")]
    public class BulletDataSO : ScriptableObject
    {
        [Header("\t\t BULLETABLE INFORMATIONS")]
        [Header("-----------------------------------------------------------")]
        [Space(35)]

        public GameObject bullet;
        public int totalBulletCount;
    }
}