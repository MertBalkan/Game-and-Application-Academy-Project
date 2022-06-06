using AcademyProject.Combats;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class SlimeItemController : BaseItemController, IBulletable
    {
        [SerializeField] private BulletDataSO bulletDataSO;
        [SerializeField] private int totalBulletCount = 0;
        public ItemDataSO ItemDataSO => itemDataSO;
        public BulletDataSO BulletDataSO => bulletDataSO;
        public bool IsDropped => isDropped;
        public bool IsStackCountOver => itemDataSO.stackCount <= 0;

        protected override void Awake()
        {
            base.Awake();
            
            bulletDataSO = Instantiate(bulletDataSO);
            bulletDataSO.totalBulletCount = totalBulletCount;
        }

        private void Update()
        {
            if (IsStackCountOver)
                Destroy(this.gameObject);
        }

        public int AmmoCount()
        {
            return itemDataSO.stackCount;
        }
    }
}