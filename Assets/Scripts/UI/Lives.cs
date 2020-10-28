using UnityEngine;
using UnityEngine.UI;

/*
 * Update Lives in the GUI
 */

public class Lives : MonoBehaviour
{
    public Image[] hearthImages;

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
        switch (lives)
        {
        case 1:
            hearthImages[0].gameObject.SetActive(true);
            hearthImages[1].gameObject.SetActive(false);
            hearthImages[2].gameObject.SetActive(false);
            break;
        case 2:
            hearthImages[0].gameObject.SetActive(true);
            hearthImages[1].gameObject.SetActive(true);
            hearthImages[2].gameObject.SetActive(false);
            break;
        case 3:
            hearthImages[0].gameObject.SetActive(true);
            hearthImages[1].gameObject.SetActive(true);
            hearthImages[2].gameObject.SetActive(true);
            break;
        }

    }
}
