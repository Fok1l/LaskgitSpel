
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    public bool zapPuzzleKeyGained = false;
    public bool tidningGained = true;
    SceneLoader loader;
    UpperBladeTest upperBladeTest;
    SaveTheBladeBool saveTheBladeBool;
    public Canvas PauseCanvas;
    [SerializeField] public bool spawnTheBookPuzzleJar = false;
    bool PauseOveride;


    [Header("spawn positions")]
    public Vector2 playerSpawnPosition;

    private void Awake()
    {
        FirstSpawn();
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

        //if (pauseMenuCanvas == null)
       // {
        //    Debug.LogError("PauseMenu_Canvas not found!");
     //   }
      //  if (pauseMenuCanvas == null)
       // {
       //     Debug.LogError("PauseMenu_Canvas not found!");
       // }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

   // private void Update()
  //  {
  //      if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        PauseOveride = true;
     //       pauseMenuCanvas.enabled = true;
    //        Time.timeScale = 0f;
     //   }
    //}

    //W.I.P Håkan
    void FirstSpawn()
    {
        if (saveTheBladeBool.stopFirstTimeSpawn == false)
        {
            playerSpawnPosition = new Vector2(7.902787f, -8.278445f);
            saveTheBladeBool.stopFirstTimeSpawn = true;
        }
    }
}