using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMB<T> : MonoBehaviour where T: MonoBehaviour
{
    private static bool _shuttingDown = false;
    private static object _lock = new object();

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_shuttingDown)
            {
                return null;
            }

            lock (_lock)
            {
                if(_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if(_instance == null)
                    {
                        GameObject singletonGameObject = new GameObject();
                        _instance = singletonGameObject.AddComponent<T>();
                        singletonGameObject.name = typeof(T).ToString() + "(Singleton)";
                        DontDestroyOnLoad(singletonGameObject);
                    }
                }
            }

            return _instance;
        }
    }

    private void OnApplicationQuit()
    {
        _shuttingDown = true;
    }

    private void OnDestroy()
    {
        _shuttingDown = true;
    }
}
