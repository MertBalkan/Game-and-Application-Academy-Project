using AcademyProject.Combats;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class DartItemController : BaseItemController, IBulletable
    {
        [SerializeField] private int totalBulletCount = 0;
        [SerializeField] private BulletDataSO bulletDataSO;
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