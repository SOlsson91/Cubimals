using UnityEngine;

public class Menu : MonoBehaviour
{
    SpawnPlayer spawner;
    [Range(1,2), SerializeField] int playersToSpawn = 2;

    void Start()
    {
        spawner = GetComponent<SpawnPlayer>();
    }

    public void StartGame(string sceneName)
    {
        for (int i = 0; i < playersToSpawn; ++i)
        {
            spawner.Spawn(i);
            Debug.Log("Spawned");
        }
        GameManager.Instance.LoadLevel(sceneName);
    }

    public void LoadScene(string sceneName)
    {
        GameManager.Instance.LoadLevel(sceneName);
        Debug.Log("Start Game input Recieved");
    }

    public void UnloadScene(string sceneName)
    {
        GameManager.Instance.UnloadLevel(sceneName);
        Debug.Log("Unload input Recieved");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit input Recieved");
    }
}
