using UnityEngine;

/*
 * If trigger entered update checkpoint on player to spawn at the middle of new checkpoint
 * Only trigger on first enter
 */

public class UpdateCheckpoint : MonoBehaviour
{
    bool checkpointTriggered;
    Vector3 checkpointPosition;

    void Awake()
    {
        checkpointTriggered = false;
        checkpointPosition = new Vector3(transform.position.x,
                                        transform.position.y / 2,
                                        transform.position.z / 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (checkpointTriggered)
            return;

        if (other.GetComponentInParent<Player>().CompareTag("Player"))
        {
            GameManager.Instance.players.ForEach(delegate(Player player){
                player.checkpoint.UpdateCheckpoint(checkpointPosition);
            });
        }
    }
}
