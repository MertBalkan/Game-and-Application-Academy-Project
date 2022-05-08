using UnityEngine;

namespace AcademyProject.Collectables
{
    public interface ICollect
    {
        void CollectOther(Collision other);
    }
}