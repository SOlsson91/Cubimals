using UnityEngine;

/*
 * Used to activate the player objecs when loading a new level. Also to show where to spawn the players
 */

public class ShowPlayer : MonoBehaviour
{
    public Vector3 offset = new Vector3(1.25f, 0.0f, 1.25f);
    void Start()
    {
        foreach (Player player in GameManager.Instance.players)
        {
            Vector3 spawnOffsetPosition = transform.position + (player.playerNumber * offset);
            player.transform.position = spawnOffsetPosition;
            player.transform.rotation = transform.rotation;
            player.gameObject.SetActive(true);
        }
    }
}
