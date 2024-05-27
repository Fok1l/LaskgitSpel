using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//Comment to fix fork
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

    GameObject soundObject; // Needed for UI click sounds
    AudioSource soundSource; // Needed for UI click sounds
    SaveTheBladeBool saveTheBladeBool;

    [SerializeField] Vector2 bladeSpawnPosition;

    SaveAndLoadPosition saveAndLoad;
    SpawnWinCanvas spawnWinCanvas;

    void Start()
    {
        saveAndLoad = FindObjectOfType<SaveAndLoadPosition>();
        spawnWinCanvas = FindObjectOfType<SpawnWinCanvas>();
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        gameSession = FindObjectOfType<GameSession>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        Debug.Log("Sceneloader Found GameSesh");
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

        if (knives == 5)
        {
            spawnWinCanvas.winPuzzleCanvas.SetActive(true);
            knives = 0;
        }
    }

    public IEnumerator ZapPuzzleSpawn() // Makes sure that you spawn at the zap puzzle when done.
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
                // If the condisions are true than set the player position and stop the IEnumerator
                playerSpawner.dontActivateSpawnTimer = true;
                playerSpawner.stopZapPuzzleSpawning = false;
                player.transform.position = playerSpawner.playerSpawnPosition;
                yield return new WaitForSeconds(0.1f);
                playerSpawner.spawnAtZapPuzzle = false;
                yield return new WaitForSeconds(0.1f);
                playerSpawner.dontActivateSpawnTimer = false;
            }
            else
            {
                StartCoroutine(ZapPuzzleSpawn());
            }
        }
    }

    public IEnumerator BladePuzzleSpawn() //A test on blade puzzle spawn, works like zap puzzle spawn, a bit broken and does not work. Dont know if we should remove
    {
        if (playerSpawner.stopZapPuzzleSpawning == true)
        {
            yield break;
        }
        else
        {
            playerSpawner.dontActivateSpawnTimer = false;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            yield return new WaitForSeconds(0.1f);

            if (currentSceneIndex == 3 && saveTheBladeBool.theBladeTestIsCompleted == true && playerSpawner.stopZapPuzzleSpawning == false)
            {
                // If the condisions are true than set the player position and stop the IEnumerator
                playerSpawner.stopZapPuzzleSpawning = true;
                player.transform.position = bladeSpawnPosition;
            }
            else
            {
                StartCoroutine(BladePuzzleSpawn());
            }
        }
    }

    public void SavePlayerPositionAndLoadScene(int sceneIndex) // Supposed to save the players position and change scene
    {
        // Save the player's position before changing the scene
        playerSpawner.SavePlayerPosition(player.transform.position);
        // Load the new scene
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //Change player position if a specific scene loads
    {
        // Check if we are back in the original scene
        if (scene.buildIndex == 3)
        {
            // Restore the player's position
            player.transform.position = playerSpawner.LoadPlayerPosition();
        }
    }

    public void Teleporters(int teleportToLocation) // Custom scene loading so you dont need multiple voids for them
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

    // Everything below this might be completely useless, but I'm saving it just incase.
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        if (currentSceneIndex == 4)
        {
            playerSpawner.playerPosition.position = player.transform.position;
        }
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
            spawnWinCanvas.winPuzzleCanvas.SetActive(true);
            //SceneManager.LoadScene(3);
            //saveAndLoad = FindObjectOfType<SaveAndLoadPosition>();
            //saveAndLoad.ResetPosition();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadEndingScene()
    {
        SceneManager.LoadScene(6);
    }

    public IEnumerator FadeInFadeOut()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
        animator.SetTrigger("FadeIn");
    }
}