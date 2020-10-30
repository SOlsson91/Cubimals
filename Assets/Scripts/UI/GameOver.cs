using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject pauseObject;

    void Start()
    {
        EventManager.Instance.onPause += Pause;
        Debug.Log("SUB");
    }

    void OnDestroy()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.onPause -= Pause;
    }

    public void GoToMainMenu()
    {
        string currentScene = GameManager.Instance.ActiveScene();
        GameManager.Instance.UnloadLevel(currentScene);
        GameManager.Instance.LoadLevel("MainMenu");
    }

    public void Pause()
    {
        pauseObject.SetActive(GameManager.Instance.isPaused);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Input Recieved");
    }
}
