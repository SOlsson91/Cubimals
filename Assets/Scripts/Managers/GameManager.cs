using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Game Manager that will handle the game

public class GameManager : Singleton<GameManager>
{
    public enum GameState // Different states the game could be in
    {
        PREGAME,
        ONGAME,
        PAUSED
    }

    public GameObject[] SystemPrefabs; // The array in which the sub-managers could be instantiated from; Not used
    public List<Player> players; // Reference to the players
    public int lives = 3; // Ammount of retries the players have 
    [HideInInspector] public bool isPaused = false; // Handling the pause

    List<GameObject> instancedSystems; // What systems are in progress to be loaded are in here; Not used
    SpawnPlayer spawner;
    List<AsyncOperation> loadOperations; // <-- Stacks operations that is being loaded additively

    GameState currentGameState = GameState.PREGAME; // <-- GameState default state is PREGAME
    LevelManager levelManager;
    [SerializeField] string levelToBoot = string.Empty;

    protected override void Awake()
    {
        base.Awake();

        players = new List<Player>();
        spawner = GetComponent<SpawnPlayer>();
        instancedSystems = new List<GameObject>();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        levelManager = GetComponent<LevelManager>();
        if (levelToBoot != string.Empty)
        {
            LoadLevel(levelToBoot);
        }
        InstantiateSystemPrefabs();
    }

    // -- Accessors -- //

    public GameState getCurrentGameState // The method to access the current state the game is in
    {
        get { return currentGameState; }
        private set { currentGameState = value; }
    }

    // -- Game State Handling -- //

    public void UpdateGameState(GameState newState) // The method to switch the states of the game
    {
        GameState previousGameState = currentGameState;
        currentGameState = newState;

        switch(currentGameState)
        {
            case GameState.PREGAME:
                break;

            case GameState.ONGAME:
                break;

            case GameState.PAUSED:
                break;

            default:
                break;
        }
    }

    // -- Manager Handling -- //

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

        if (instancedSystems != null)
        {
            for(int i = 0; i < instancedSystems.Count; i++)
            {
                Destroy(instancedSystems[i]);
            }
            instancedSystems.Clear();
        }
    }

    public void LoadLevel(string levelName) // calls the LoadLevel method of the levelManager with the name of the level
    {
        levelManager.LoadLevel(levelName);
    }

    public void UnloadLevel(string levelName) // calls the UnloadLevel method of the levelManager with the name of the level
    {
        levelManager.UnloadLevel(levelName);
    }

    public string ActiveScene() => levelManager.ActiveScene;

    // Clear the child players
    public void ClearPlayers()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        players.Clear();
    }

    public void ResetLives() => lives = 3;
}
