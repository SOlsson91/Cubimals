using UnityEngine;


/// <summary>
/// This class is used for making a single instance of a type( <typeparamref name="T"/> ) which should only have one instance of itself
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T getInstance
    {
        get { return instance; }
    }

    /// <summary>
    /// Will return wether or not an instance already exists of the type
    /// </summary>
    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Trying to instantiate a second instance of a singleton class");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
