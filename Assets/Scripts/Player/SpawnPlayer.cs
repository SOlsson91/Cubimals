using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerPrefab;
    [SerializeField] Transform[] spawnPosition;
    GameManager manager;
    public int numberOfPlayers = 2;

    void Awake()
    {
        manager = GetComponent<GameManager>();
    }

    void Start()
    {
        for (int i = 0; i < numberOfPlayers; ++i)
        {
            Spawn(i);
        }
    }

    public void Spawn(int playerNumber)
    {
           Player player = Instantiate(playerPrefab, spawnPosition[playerNumber].position, 
                                               spawnPosition[playerNumber].rotation);
           player.playerNumber = playerNumber;
           manager.players.Add(player);
    }
}
