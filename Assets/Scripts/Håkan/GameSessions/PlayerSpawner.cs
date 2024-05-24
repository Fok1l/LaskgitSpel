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

    public bool dontActivateSpawnTimer;
    public bool dontSpawnBladePuzzle;
    public bool spawnBladePuzzle;
    public bool spawnAtZapPuzzle = false;
    public bool stopZapPuzzleSpawning = false;
    // Start is called before the first frame update
    
    
    public Transform playerPosition;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();

        playerPosition = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
      //  playerPosition = FindObjectOfType<PlayerMove>().transform;
    }

    //W.I.P Håkan
    void FirstSpawn()
    {
        if (saveTheBladeBool.stopFirstTimeSpawn == false)
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
