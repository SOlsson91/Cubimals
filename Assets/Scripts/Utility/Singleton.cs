using UnityEngine;

// This class is used for making a single instance of a type( <typeparamref name="T"/> ) which should only have one instance of itself

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    /// Will return wether or not an instance already exists of the type

    public static bool IsInitialized
    {
        get { return Instance != null; }
    }

    protected virtual void Awake()
    {
        if(IsInitialized)
        {
            Debug.LogError("Trying to instantiate a second instance of a singleton class");
        }
        else
        {
            Instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
}
