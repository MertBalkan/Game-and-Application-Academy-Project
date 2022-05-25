using AcademyProject.Combats;
using AcademyProject.SpecialEffects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class LegoItemController : BaseItemController, ITrapable
    {
        [SerializeField] private GameObject trap;
        public bool IsTrapActive => isDropped;
        
        private void Update()
        {
            TrapEffect();
        }

        public void TrapEffect()
        {
            if (IsTrapActive)
            {
                Destroy(this.gameObject);
                var trapObj = Instantiate(trap);
                trapObj.transform.position = this.transform.position + Vector3.up * 2;
            }
        }
    }
}