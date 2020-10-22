using UnityEngine;

/*
 * If player hits collider respawn it at the latest checkpoint
 * TODO: Maybe add only respawn if other player is nearby?
 */

public class DeadCollider : MonoBehaviour
{
    public Vector3 spawnOffset = new Vector3(0.0f, 1.25f, 0.0f);

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.players.ForEach(delegate(Player player) {
                int playerNumber = other.gameObject.GetComponent<Player>().playerNumber;

                // Only update the player that entered the collider and not both
                if (player.playerNumber == playerNumber)
                {
                    Vector3 respawnPoint = player.checkpoint.GetCheckpoint();
                    other.transform.position = respawnPoint + (spawnOffset * playerNumber);
                }
            });
        }
    }
}
