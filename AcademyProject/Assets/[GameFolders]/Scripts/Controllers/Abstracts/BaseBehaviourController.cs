using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public abstract class BaseBehaviourController : MonoBehaviour
    {
        public ItemDataSO itemDataSO;
        public bool isInInventory;
        public int stackQuantity;
    }
}