using UnityEngine;

namespace AcademyProject.Managers
{
    /// <summary>
    /// Abstract class template for "Singleton Pattern"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
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