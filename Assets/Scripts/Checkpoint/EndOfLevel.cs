using UnityEngine;

/*
 * Last Checkpoint of the level, will move you to the next level. However
 * only when both players are in the trigger area
 */

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] string nextLevel = string.Empty;
    int playersInGoal = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>().CompareTag("Player"))
        {
            playersInGoal++;

            if (playersInGoal == 2)
            {
                if (nextLevel != string.Empty)
                {
                    Debug.Log("[EndOfLevel] Load Next Level");
                    string currentScene = GameManager.Instance.ActiveScene();
                    GameManager.Instance.players.ForEach(delegate(Player player) { player.gameObject.SetActive(false); });
                    GameManager.Instance.UnloadLevel(currentScene);
                    GameManager.Instance.LoadLevel(nextLevel);
                }
                else
                {
                    Debug.LogWarning("[EndOfLevel] What level do you want to load?");
                    return;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Player>().CompareTag("Player"))
            playersInGoal--;
    }

}
