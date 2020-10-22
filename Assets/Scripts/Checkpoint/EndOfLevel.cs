using UnityEngine;

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
                    Debug.Log("NEXT LEVEL");
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
        {
            playersInGoal--;
        }
    }

}
