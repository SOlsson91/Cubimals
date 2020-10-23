using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameManager.Instance.LoadLevel(sceneName);
        Debug.Log("Start Game input Recieved");
    }

    public void UnloadScene(string sceneName)
    {
        GameManager.Instance.UnloadLevel(sceneName);
        Debug.Log("Unload input Recieved");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit input Recieved");
    }
}
