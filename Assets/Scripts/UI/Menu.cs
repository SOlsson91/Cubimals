using UnityEngine;

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
        if (GameManager.Instance.players.Count < 2)
        {
            for (int i = 0; i < playersToSpawn; ++i)
            {
                spawner.Spawn(i);
                Debug.Log("[Menu] Spawned player " + i );
            }
        }

        GameManager.Instance.ResetLives();
        GameManager.Instance.LoadLevel(sceneName);
        startGame.SetActive(false);//Edit: quick fix for double clicking start game and loadig 2 istances of the level
    }

    public void LoadScene(string sceneName)
    {
        GameManager.Instance.LoadLevel(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        GameManager.Instance.UnloadLevel(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
