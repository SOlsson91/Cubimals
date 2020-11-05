using System;

/*
 * Events are not used much in the game but helps when the game is paused and when lives are lost
 * this since there are multiple areas of the code that need to access that.
 */

public class EventManager : Singleton<EventManager>
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public event Action<int> onLivesLost;
    public void LivesLost(int lives)
    {
        if (onLivesLost != null)
        {
            onLivesLost(lives);
        }
    }

    public event Action onPause;
    public void Pause()
    {
        if (onPause != null)
        {
            onPause();
        }
    }
}
