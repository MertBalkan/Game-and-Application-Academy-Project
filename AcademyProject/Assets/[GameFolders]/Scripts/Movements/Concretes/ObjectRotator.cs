using UnityEngine;

namespace AcademyProject.Movements
{
    public class ObjectRotator : MonoBehaviour
    {
        void Update()
        {
            RotateMe();
        }

        private void RotateMe()
        {
            transform.Rotate(Vector3.down * 90.0f * Time.deltaTime);
        }
    }
}