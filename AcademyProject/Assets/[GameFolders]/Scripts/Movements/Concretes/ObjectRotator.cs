using UnityEngine;

namespace AcademyProject.Movements
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 rotVector;
        void Update()
        {
            RotateMe();
        }

        private void RotateMe()
        {
            transform.Rotate(rotVector * 180.0f * Time.deltaTime);
        }
    }
}