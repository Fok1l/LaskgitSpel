using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    SaveTheBladeBool saveTheBladeBool;
    GameSession gameSession;
    SceneLoader sceneLoader;

    [Header("spawn positions")]
    public Vector2 playerSpawnPosition;
    public GameObject playerCamera;
    [SerializeField] GameObject playerInGame;

    public bool dontActivateSpawnTimer;
    public bool dontSpawnBladePuzzle;
    public bool spawnBladePuzzle;
    public bool spawnAtZapPuzzle = false;
    public bool stopZapPuzzleSpawning = false;
    public bool stopWireSpawning = false;
    // Start is called before the first frame update
    
    
    public Transform playerPosition;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        playerSpawnPosition = new Vector2(7.902787f, -8.278445f);
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();

        playerPosition = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (saveTheBladeBool.stopFirstTimeSpawn == true && gameSession.wirePuzzleComplete == true && stopWireSpawning == false)
        {
            playerSpawnPosition = new Vector2(6.538782f, 7.561572f);
            playerCamera.transform.position = playerSpawnPosition;
            playerPosition.transform.position = playerSpawnPosition;
            playerInGame.transform.position = playerSpawnPosition;
            stopWireSpawning = true;
        }
    }

    //W.I.P Håkan
    void FirstSpawn()
    {
        if (saveTheBladeBool.stopFirstTimeSpawn == false && gameSession.wirePuzzleComplete == false)
        {
            playerSpawnPosition = new Vector2(7.902787f, -8.278445f);
            playerCamera.transform.position = playerSpawnPosition;
            saveTheBladeBool.stopFirstTimeSpawn = true;
        }
    }

    public void SavePlayerPosition(Vector3 position)
    {
        playerPosition.position = position;
    }

    public Vector3 LoadPlayerPosition()
    {
        return playerPosition.position;
    }
}
