using UnityEngine;

/*
 * Simple generic Singelton for MonoBehaviour classes
 */

public class Singelton<T> : MonoBehaviour where T : Singelton<T>
{
    public static T Instance { get; private set; }

    public static bool IsInitialized
    {
        get { return Instance != null; }
    }

    protected virtual void Awake()
    {
        if (IsInitialized)
        {
            Debug.LogError("[Singelton] Trying to instantiate a second instance of gameobject");
        }
        else 
        {
            Instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }    
}
