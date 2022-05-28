using UnityEngine;
using Random = UnityEngine.Random;

namespace AcademyProject.SpecialEffects
{
    public class SlideEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private float slideSpeed = 10f;

        private void Start()
        {
            Destroy(this.gameObject, 5.0f);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                ApplyEffect(collision);
        }

        public void ApplyEffect(Collision collision)
        {
            var otherRb = collision.gameObject.GetComponent<Rigidbody>();
            otherRb.AddForce(transform.forward * Mathf.Sin(Random.Range(1f, 3f)) * slideSpeed, ForceMode.VelocityChange);
        }
    }
}