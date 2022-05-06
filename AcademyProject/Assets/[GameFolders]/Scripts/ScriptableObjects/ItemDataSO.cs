using UnityEditor;
using UnityEngine;

namespace AcademyProject.ScriptableObjects
{
    /// <summary>
    /// This class contains data information about items
    /// </summary>
    [CreateAssetMenu(menuName = "AcademyProject/Create New Item")]
    public class ItemDataSO : ScriptableObject
    {
        [Header("\t\tITEM INFORMATIONS")]
        [Space(35)]
        
        public string itemName;
        [TextArea] public string itemDescription;
        public GameObject itemObject;

        public bool isDamageable;
    }
}
