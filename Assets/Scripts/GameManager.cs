using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-- TODO --
// > Keep track of what level is currently on
// > Load and Unload scenes
// > Keep track of what state the game is in
// > Generate other persistent systems

public class GameManager : Singleton<GameManager>
{
    public GameObject[] SystemPrefabs;

    private List<GameObject> instancedSystems;

    private string currentSceneName = string.Empty;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadScene("DummyScene");

        InstantiateSystemPrefabs();
    }

    private void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for(int i = 0; i < SystemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            instancedSystems.Add(prefabInstance);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        for(int i = 0; i < instancedSystems.Count; i++)
        {
            Destroy(instancedSystems[i]);
        }

        instancedSystems.Clear();
    }

    public void LoadScene(string sceneName)
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        if(asyncOp == null)
        {
            Debug.LogError("Could not find " + sceneName + " | Make sure the scene is added to the build list");
            return;
        }

        asyncOp.completed += OnLoadComplete;

        currentSceneName = sceneName;
    }

    public void UnloadScene(string sceneName)
    {
        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(sceneName);
        asyncOp.completed += OnUnloadComplete;
    }

    private void OnLoadComplete(AsyncOperation asyncOp)
    {
        Debug.Log("Load Complete");
    }

    private void OnUnloadComplete(AsyncOperation asyncOp)
    {
        Debug.Log("Load Complete");
    }
}
