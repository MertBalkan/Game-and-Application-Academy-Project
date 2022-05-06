using System.Collections;
using System.Collections.Generic;
using AcademyProject.ScriptableObjects;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public abstract class BaseItemController : MonoBehaviour
    {
        [SerializeField] private ItemDataSO itemDataSO;
    }
}