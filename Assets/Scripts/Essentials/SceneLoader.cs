using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameSession gameSession;
    [SerializeField] GameObject player;
    public Animator animator;
    private int leveltoload;
    [SerializeField]int knives;
    public Canvas transitionCanvas;

    GameObject soundObject; // Needed for UI click sounds
    AudioSource soundSource; // Needed for UI click sounds
    SaveTheBladeBool saveTheBladeBool;
    private void Start()
    {

        gameSession = FindObjectOfType<GameSession>();
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
        // WORK IN PROGRESS!
        if (gameSession.zapPuzzleKeyGained == true && saveTheBladeBool.theBladeTestIsCompleted == false)
        {
            player.transform.position = new Vector3(16.74797f, 2.618468f, 0f);
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