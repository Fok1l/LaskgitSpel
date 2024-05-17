using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheBladeBool : MonoBehaviour
{
    public static SaveTheBladeBool Instance;
    
    public bool theBladeTestIsCompleted = false;
    public bool tutorialText = false;
    public bool stopFirstTimeSpawn = false;
    bool stopBladeSpawnSpam = false;

    SceneLoader loader;
    PlayerSpawner spawner;
    GameSession gameSession;
    PlayerSpawner playerSpawner;

    private void Start()
    {
        spawner = FindObjectOfType<PlayerSpawner>();
        gameSession = FindObjectOfType<GameSession>();
        loader = FindObjectOfType<SceneLoader>();
        playerSpawner = FindObjectOfType<PlayerSpawner>();
    }
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(theBladeTestIsCompleted == true && stopBladeSpawnSpam == false && loader.knives == 5)
        {
            spawner.dontActivateSpawnTimer = false;
            spawner.playerSpawnPosition = new Vector3(-1.320004f, 10.15893f, 0f);
            //gameSession.HoldPlayerSpawn();
            stopBladeSpawnSpam = true;
        }
        else
        {
            return;
        }
    }
}
