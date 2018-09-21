using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).FullName);
                        instance = go.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
    }
}