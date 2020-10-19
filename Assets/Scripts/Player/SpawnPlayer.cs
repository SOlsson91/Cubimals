using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerToSpawn;
    [SerializeField] Transform[] spawnPosition;

    void Start()
    {
        for (int i = 0; i < spawnPosition.Length; ++i)
        {
           Player p = Instantiate(playerToSpawn, spawnPosition[i].position, spawnPosition[i].rotation);
           p.playerNumber = i;
        }
    }
}
