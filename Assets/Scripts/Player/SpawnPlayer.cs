using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerPrefab;
    [SerializeField] Transform[] spawnPosition;
    GameManager manager;

    void Awake()
    {
        manager = GetComponent<GameManager>();
    }

    void Start()
    {
        for (int i = 0; i < spawnPosition.Length; ++i)
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
