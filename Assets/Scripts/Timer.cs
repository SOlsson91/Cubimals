using UnityEngine;

/*
 * Simple Time class to be used to get the time it takes for a player to finish a level
 */

public class Timer : MonoBehaviour
{
    public bool startOnLoad = true;
    float time;
    bool isActive = false;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    void Start()
    {
        time = 0;
        isActive = startOnLoad;
    }

    void Update()
    {
        if (isActive)
        {
            time += Time.deltaTime;
        }
    }
    public void ResetTimer() { time = 0; }
    public float GetTime() { return time; }
}
