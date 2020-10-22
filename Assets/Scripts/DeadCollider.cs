using UnityEngine;

public class DeadCollider : MonoBehaviour
{
    public Transform respawnPoint;
    public Vector3 spawnOffset = new Vector3(0.0f, 1.25f, 0.0f);

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.players.ForEach(delegate(Player player) {
                int playerNumber = other.gameObject.GetComponent<Player>().playerNumber;
                if (player.playerNumber == playerNumber)
                {
                    other.transform.position = respawnPoint.position + (spawnOffset * playerNumber);
                }
            });
        }
    }
}
