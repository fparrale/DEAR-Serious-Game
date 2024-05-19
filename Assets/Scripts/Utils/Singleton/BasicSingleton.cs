
using System;
using UnityEngine;

namespace Utils.Singleton
{
    public class BasicSingleton<T> : MonoBehaviour where T : Component 
    {
        protected static T instance;

        public static bool existsInstance => instance != null;
        public static T TryGetInstance() => existsInstance ? instance : null;

        public static T Instance 
        {
            get {
                if(existsInstance == false)
                {
                    instance = FindAnyObjectByType<T>();

                    if(existsInstance == false)
                    {
                        var gameObject = new GameObject(typeof(T).Name);
                        instance = gameObject.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            InitInstance();
        }

        protected virtual void InitInstance()
        {
            if(!Application.isPlaying) return;

            instance = this as T;
        }
    }
}