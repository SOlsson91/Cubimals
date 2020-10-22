using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerPrefab = null;
    [SerializeField] Transform spawnPosition = null;
    public Vector3 offset = new Vector3(0.0f, 1.25f, 0.0f);
    [Range(1,2), SerializeField] int playersToSpawn = 2;

    void Start()
    {
        for (int i = 0; i < playersToSpawn; ++i)
        {
            Spawn(i);
        }
    }

    public void Spawn(int playerNumber)
    {
        Vector3 spawnOffsetPosition = spawnPosition.position + (playerNumber * offset);

        Player player = Instantiate(playerPrefab, spawnOffsetPosition, spawnPosition.rotation);
        player.playerNumber = playerNumber;
        GameManager.Instance.players.Add(player);
    }
}
