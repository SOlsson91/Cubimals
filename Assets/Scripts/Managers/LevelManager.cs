using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Manager to switch between scenes
 */

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName) => StartCoroutine(LoadAsync(levelName));
    public void UnloadLevel(string levelName) => StartCoroutine(UnloadAsync(levelName));

    IEnumerator LoadAsync(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if (operation == null)
            Debug.LogErrorFormat("[LevelManager]: Unable to load level: {0}", levelName);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator UnloadAsync(string levelName)
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(levelName);

        if (operation == null)
            Debug.LogErrorFormat("[LevelManager]: Unable to unload level: {0}", levelName);

        while(!operation.isDone)
        {
            yield return null;
        }
    }
}
