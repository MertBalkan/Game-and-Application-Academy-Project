using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public abstract class BaseBehaviourController : MonoBehaviour
    {
        [Header("ITEM DATA")]
        [Space(20)]
        public ItemDataSO itemDataSO;
        public bool isInInventory;
        public int stackQuantity;
        [Header("---------------------------------------------------------")]
        public bool isDropped;
    }
}