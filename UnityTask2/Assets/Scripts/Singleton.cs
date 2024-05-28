using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if(instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name,typeof(T));
                    instance = go.GetComponent<T>();
                }
            }

            return instance;
        }

    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this as T;
    }
}
