using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Combats
{
    public interface IBulletable
    {
        int AmmoCount();
        ItemDataSO ItemDataSO { get; }
        BulletDataSO BulletDataSO { get; }
        bool IsDropped { get; }
        bool IsStackCountOver { get; }
    }   
}