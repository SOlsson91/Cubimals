using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI mainMenuButton;
    public TextMeshProUGUI quitButton;

    public void GoToMainMenu()
    {
        string currentScene = GameManager.Instance.ActiveScene();
        GameManager.Instance.UnloadLevel(currentScene);
        GameManager.Instance.LoadLevel("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Input Recieved");
    }
}
