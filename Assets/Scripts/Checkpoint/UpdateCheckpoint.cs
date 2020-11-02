using UnityEngine;

/*
 * If trigger entered update checkpoint on player to spawn at the middle of new checkpoint
 * Only trigger on first enter
 */

public class UpdateCheckpoint : MonoBehaviour
{
    Vector3 checkpointPosition;

    void Awake()
    {
        checkpointPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update for each player when one of them enter the checkpoint. Then turn off the checkpoint so we dont activate it again
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>().CompareTag("Player"))
        {
            GameManager.Instance.players.ForEach(delegate(Player player){
                player.checkpoint.Position = checkpointPosition;
            });
        }

        gameObject.SetActive(false);
    }
}
