using AcademyProject.Combats;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class FastenerItemController : BaseItemController, IBulletable
    {
        [SerializeField] private GameObject bulletGameObject;
        public GameObject ItemObject => bulletGameObject;
        public ItemDataSO ItemDataSO => itemDataSO;
        public bool IsDropped => isDropped;

        private void Update()
        {
            if (itemDataSO.stackCount <= 0)
                Destroy(this.gameObject);
        }
        
        public int AmmoCount()
        {
            return itemDataSO.stackCount;
        }
    }
}