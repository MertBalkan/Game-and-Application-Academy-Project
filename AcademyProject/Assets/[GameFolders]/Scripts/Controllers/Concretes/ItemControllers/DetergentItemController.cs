using AcademyProject.Combats;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class DetergentItemController : BaseItemController, ITrapable
    {
        [SerializeField] private GameObject trap;
        public bool IsTrapActive => isDropped;
        private bool _isSpawnedEffect = false;
        
        private void Update()
        {
            TrapEffect();
        }     

        public void TrapEffect()
        {
            if (IsTrapActive && !_isSpawnedEffect)
            {
                _isSpawnedEffect = true;
                Destroy(this.gameObject);
                var trapObj = Instantiate(trap);
                trapObj.transform.position = this.transform.position + Vector3.up * 2;
            }
        }
    }
}