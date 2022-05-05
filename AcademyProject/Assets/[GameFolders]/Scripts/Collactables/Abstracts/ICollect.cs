using UnityEngine;

namespace AcademyProject.Collectables
{
    public interface ICollect
    {
        void CollectOther(Collider other);
    }
}