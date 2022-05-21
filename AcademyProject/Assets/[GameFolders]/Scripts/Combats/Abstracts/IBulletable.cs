using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Combats
{
    public interface IBulletable
    {
        int AmmoCount();
        GameObject ItemObject { get; }
        ItemDataSO ItemDataSO { get; }
        bool IsDropped { get; }
    }   
}