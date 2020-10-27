using UnityEngine;
using TMPro;

/*
 * Update Lives in the GUI
 */

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLives(GameManager.Instance.lives);
        Debug.Log(EventManager.Instance);
        EventManager.Instance.onLivesLost += UpdateLives;
    }

    void OnDestroy()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.onLivesLost -= UpdateLives;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}
