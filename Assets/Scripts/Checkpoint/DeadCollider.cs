using UnityEngine;

/*
 * If player hits collider respawn it at the latest checkpoint
 * TODO: Maybe add only respawn if other player is nearby?
 */

public class DeadCollider : MonoBehaviour
{
    public Vector3 spawnOffset = new Vector3(1.25f, 0.0f, 1.25f);

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponentInParent<Player>().gameObject.tag);
        if (other.GetComponentInParent<Player>().gameObject.CompareTag("Player"))
        {
            DecreaseALife();
            GameManager.Instance.players.ForEach(delegate(Player player) {
                int playerNumber = other.gameObject.GetComponentInParent<Player>().playerNumber;

                // Only update the player that entered the collider and not both
                if (player.playerNumber == playerNumber)
                {
                    Vector3 respawnPoint = player.checkpoint.GetCheckpoint();
                    player.transform.position = respawnPoint + (spawnOffset * playerNumber);
                }
            });
        }
    }

    void DecreaseALife()
    {
        EventManager.Instance.LivesLost(--GameManager.Instance.lives);

        if (GameManager.Instance.lives <= 0)
        {
            Debug.LogWarning("[DeadCollider] Out of lives, GameOver!");
            //GameManager.Instance.LoadLevel("GameOver");
        }
    }
}
