using System;

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
}
