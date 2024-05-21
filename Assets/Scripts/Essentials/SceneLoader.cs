using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        saveAndLoad = FindObjectOfType<SaveAndLoadPosition>();

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

    public IEnumerator BladePuzzleSpawn()
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
                playerSpawner.stopZapPuzzleSpawning = true;
                player.transform.position = bladeSpawnPosition;
            }
            else
            {
                StartCoroutine(BladePuzzleSpawn());
            }
        }
    }

    public void SavePlayerPositionAndLoadScene(int sceneIndex)
    {
        // Save the player's position before changing the scene
        playerSpawner.SavePlayerPosition(player.transform.position);
        // Load the new scene
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if we are back in the original scene
        if (scene.buildIndex == 3)
        {
            // Restore the player's position
            player.transform.position = playerSpawner.LoadPlayerPosition();
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
            SceneManager.LoadScene(3);
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
        SceneManager.LoadScene(5);
    }
}