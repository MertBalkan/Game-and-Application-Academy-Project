using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyProject.Managers
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void ApplySingleton(T gameObject)
        {
            if (Instance == null)
            {
                Instance = gameObject;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}