using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    SpawnPlayer spawner;
    [Range(1,2), SerializeField] int playersToSpawn = 2;

    public GameObject startGame;//Edit: quick fix for double clicking start game and loadig 2 istances of the level

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
        GameManager.Instance.ResetLives();
        GameManager.Instance.LoadLevel(sceneName);
        startGame.SetActive(false);//Edit: quick fix for double clicking start game and loadig 2 istances of the level
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
