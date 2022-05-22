using AcademyProject.Combats;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class FastenerItemController : BaseItemController, IBulletable
    {
        [SerializeField] private BulletDataSO bulletDataSO;

        [SerializeField] private int totalBulletCount = 0;
        public ItemDataSO ItemDataSO => itemDataSO;
        public BulletDataSO BulletDataSO => bulletDataSO;
        public bool IsDropped => isDropped;

        protected override void Awake()
        {
            base.Awake();
            
            bulletDataSO = Instantiate(bulletDataSO);
            bulletDataSO.TotalBulletCount = totalBulletCount;
        }

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