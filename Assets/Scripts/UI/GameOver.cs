using UnityEngine;

public class GameOver : MonoBehaviour
{
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
