using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerPrefab;
    [SerializeField] Transform[] spawnPosition;
    GameManager manager;
    bool playersReady = false;

    void Awake()
    {
        manager = GetComponent<GameManager>();
    }

    void Start()
    {
        //StartCoroutine("WaitForPlayers");
        for (int i = 0; i < spawnPosition.Length; ++i)
        {
            Spawn(i);
        }
    }
/*
    IEnumerator WaitForPlayers()
    {
        while (!playersReady)
        {
           if (playersReady)
              playersReady = true; 
        }
        yield return;
    }
*/
    public void Spawn(int playerNumber)
    {
           Player player = Instantiate(playerPrefab, spawnPosition[playerNumber].position, 
                                               spawnPosition[playerNumber].rotation);
           //PlayerInput pi = player.GetComponent<PlayerInput>();
           player.playerNumber = playerNumber;
           manager.players.Add(player);
    }
}
