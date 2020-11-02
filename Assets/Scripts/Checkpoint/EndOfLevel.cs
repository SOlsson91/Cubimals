using UnityEngine;
using TMPro;

/*
 * Last Checkpoint of the level, will move you to the next level. However
 * only when both players are in the trigger area
 */

public class EndOfLevel : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    [SerializeField] string nextLevel = string.Empty;
    int playersInGoal = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>().CompareTag("Player"))
        {
            playersInGoal++;
            textInfo.gameObject.SetActive(true);

            if (playersInGoal == 2)
            {
                if (nextLevel != string.Empty)
                {
                    Debug.Log("[EndOfLevel] Load Next Level");
                    GameManager.Instance.players.ForEach(delegate(Player player)
                    {
                        player.gameObject.SetActive(false);
                        if (nextLevel == "Victory")
                            Destroy(player);
                    });

                    if (nextLevel == "Victory")
                        GameManager.Instance.players.Clear();

                    string currentScene = GameManager.Instance.ActiveScene();
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
        textInfo.gameObject.SetActive(false);
        if (other.GetComponentInParent<Player>().CompareTag("Player"))
            playersInGoal--;
    }
}
