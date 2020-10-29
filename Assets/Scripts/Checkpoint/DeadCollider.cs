using System.Collections;
using UnityEngine;

/*
 * If player hits collider respawn it at the latest checkpoint
 * TODO: Maybe add only respawn if other player is nearby?
 */

public class DeadCollider : MonoBehaviour
{
    bool isLosingLife = false;
    public Vector3 spawnOffset = new Vector3(1.25f, 0.0f, 1.25f);

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponentInParent<Player>().gameObject.tag);
        if (other.GetComponentInParent<Player>().gameObject.CompareTag("Player"))
        {
            GameManager.Instance.players.ForEach(delegate(Player player) {
                int playerNumber = other.gameObject.GetComponentInParent<Player>().playerNumber;

                // Only update the player that entered the collider and not both
                if (player.playerNumber == playerNumber)
                {
                    Vector3 respawnPoint = player.checkpoint.Position;
                    player.transform.position = respawnPoint + (spawnOffset * playerNumber);
                }
            });
            if (!isLosingLife)
            {
                isLosingLife = true;
                DecreaseALife();
                StartCoroutine("LifeTimer");
            }
        }
    }

    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(0.5f);
        isLosingLife = false;
    }

    void DecreaseALife()
    {
        EventManager.Instance.LivesLost(--GameManager.Instance.lives);

        if (GameManager.Instance.lives <= 0)
        {
            GameManager.Instance.ClearPlayers();
            Debug.LogWarning("[DeadCollider] Out of lives, GameOver!");
            string currentScene = GameManager.Instance.ActiveScene();
            GameManager.Instance.UnloadLevel(currentScene);
            GameManager.Instance.LoadLevel("GameOver");
        }
    }
}
