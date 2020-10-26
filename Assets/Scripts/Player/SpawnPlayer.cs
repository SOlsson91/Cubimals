using UnityEngine;

/*
 * Class to spawn the player Prefab at a specific location
 */

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Player playerPrefab = null;

    public void Spawn(int playerNumber)
    {
        Player player = Instantiate(playerPrefab, GameManager.Instance.transform);
        player.gameObject.SetActive(false);
        player.playerNumber = playerNumber;
        GameManager.Instance.players.Add(player);
    }
}
