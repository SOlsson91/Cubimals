using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player[] playerToSpawn;
    [SerializeField] Transform[] spawnPosition;

    void Start()
    {
        for (int i = 0; i < playerToSpawn.Length; ++i)
        {
            Instantiate(playerToSpawn[i], spawnPosition[i].position, spawnPosition[i].rotation);
        }
    }
}
