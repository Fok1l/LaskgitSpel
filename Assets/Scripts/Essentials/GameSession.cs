
using System.Collections;
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    public bool zapPuzzleKeyGained = false;
    public bool tidningGained = true;
    SceneLoader loader;
    UpperBladeTest upperBladeTest;
    SaveTheBladeBool saveTheBladeBool;
    PlayerMove playerMove;
    public Canvas PauseCanvas;
    [SerializeField] public bool spawnTheBookPuzzleJar = false;
    bool PauseOveride;
    bool firstPlayerSpawn = false;


    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        Debug.Log("gameSession found it self");
        //pauseMenuCanvas.enabled = false;

        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }

    private void Start()
    {
           loader = FindObjectOfType<SceneLoader>();
        upperBladeTest = FindObjectOfType<UpperBladeTest>();
        saveTheBladeBool = GetComponent<SaveTheBladeBool>();

        playerMove = FindObjectOfType<PlayerMove>();
    }
    
    void Update()
    {
        if(firstPlayerSpawn == false)
        {
            playerMove.transform.position = new Vector2(7.902787f, -8.278445f);
            firstPlayerSpawn = true;
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void HoldPlayerSpawn()
    {
        if (saveTheBladeBool.stopFirstTimeSpawn == true)
        {
            StartCoroutine(loader.ZapPuzzleSpawn());
            saveTheBladeBool.stopFirstTimeSpawn = false;
        }
    }
}