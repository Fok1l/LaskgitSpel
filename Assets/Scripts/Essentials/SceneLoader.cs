using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    PlayerSpawner playerSpawner;
    [SerializeField] GameSession gameSession;
    [SerializeField] public GameObject player;
    public Animator animator;
    private int leveltoload;
    public int knives;
    [SerializeField] int playerCount;
    public Canvas transitionCanvas;
    public bool dontActivateTimer;
    bool stopZapPuzzleSpawning = false;

    GameObject soundObject; // Needed for UI click sounds
    AudioSource soundSource; // Needed for UI click sounds
    SaveTheBladeBool saveTheBladeBool;

    private void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        gameSession = FindObjectOfType<GameSession>();
        Debug.Log("Sceneloader Found GameSesh");
        player = GameObject.FindGameObjectWithTag("Player");
    }

   

    void Awake()  // Needed for UI click sounds
    {
        // Create the persistent sound object if it doesn't exist
        if (soundObject == null)
        {
            soundObject = new GameObject("UISoundObject");
            DontDestroyOnLoad(soundObject);
            soundSource = soundObject.AddComponent<AudioSource>(); // Unimplemented
        }
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 3 && playerSpawner.dontActivateSpawnTimer == false)
        {
            StartCoroutine(ZapPuzzleSpawn());
        }
    }

    public IEnumerator ZapPuzzleSpawn()
    {
        if (playerSpawner.dontActivateSpawnTimer == true)
        {
            yield break;
        }
        else
        {
            playerSpawner.dontActivateSpawnTimer = false;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            yield return new WaitForSeconds(0.1f);

            if (currentSceneIndex == 3 && playerSpawner.spawnAtZapPuzzle == true)
            {
                playerSpawner.dontActivateSpawnTimer = true;
                player.transform.position = playerSpawner.playerSpawnPosition;
                playerSpawner.playerCamera.transform.position = playerSpawner.playerSpawnPosition;
            }
            else
            {
                StartCoroutine(ZapPuzzleSpawn());
            }
        }
    }

    public IEnumerator BladePuzzleSpawn()
    {
        if (stopZapPuzzleSpawning == true)
        {
            yield break;
        }
        else
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            yield return new WaitForSeconds(0.1f);

            if (currentSceneIndex == 3 && saveTheBladeBool.theBladeTestIsCompleted == true)
            {
                stopZapPuzzleSpawning = true;
                player.transform.position = playerSpawner.playerSpawnPosition;
                playerSpawner.playerCamera.transform.position = playerSpawner.playerSpawnPosition;
            }
            else
            {
                StartCoroutine(BladePuzzleSpawn());
            }
        }
    }

    public void Teleporters(int teleportToLocation)
    {
        SceneManager.LoadScene(teleportToLocation);
    }
    
    public void FadeToLevel(int LevelIndex)
    {
        leveltoload = LevelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnFadeComplete()    
    {
        SceneManager.LoadScene(leveltoload);
    }



    
  //  private void Update()
  //  {
 //       if (Input.GetKey(KeyCode.Space)){
//            animator.SetTrigger("FadeOut");
        //}
  //  }


    // Everything below this might be completely useless, but I'm saving it just incase.

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        Debug.Log("Next Scene Loaded");
    }



    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex - 1);
        Debug.Log("Prev Scene Loaded");
    }


   
    public void QuitGame()
    {
        // Only works in built version of game, not in editor
        Debug.Log("Quitting Game");
        Application.Quit(3);
    }


    public void BladePuzzleComplete()
    {
        knives++;
        if (knives == 5)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadEndingScene()
    {
        SceneManager.LoadScene(5);
    }


}