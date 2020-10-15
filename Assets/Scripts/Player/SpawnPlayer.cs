using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerToSpawn;
    [SerializeField] Transform spawnPosition;

    void Start()
    {
        Instantiate(playerToSpawn, spawnPosition.position, spawnPosition.rotation);
    }
}
