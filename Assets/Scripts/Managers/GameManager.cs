using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.Events;

//-- TODO --
// > Keep track of what state the game is in [DONE]
// > Generate other persistent systems [DONE]

//[System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        ONGAME,
        PAUSED
    }

    public GameObject[] SystemPrefabs;
    //public EventGameState OnGameStateChange;
    public List<Player> players;
    public int lives = 3;
    [HideInInspector] public bool isPaused = false;

    List<GameObject> instancedSystems;
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

    public GameState getCurrentGameState
    {
        get { return currentGameState; }
        private set { currentGameState = value; }
    }

    // -- Game State Handling -- //

    public void UpdateGameState(GameState newState)
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

        //OnGameStateChange.Invoke(currentGameState, previousGameState); // <-- This sends a message to those who listens to this method
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

    public void LoadLevel(string levelName)
    {
        levelManager.LoadLevel(levelName);
    }

    public void UnloadLevel(string levelName)
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
