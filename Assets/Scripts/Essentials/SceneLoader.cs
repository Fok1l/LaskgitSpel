using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameSession gameSession;
    public Animator animator;
    private int leveltoload;
    [SerializeField]int knives;
    private void Start()
    {

        gameSession = FindObjectOfType<GameSession>();
        Debug.Log("Sceneloader Found GameSesh");
    }

    public void FadeToLevel(int LevelIndex)
    {
        leveltoload = LevelIndex;
        animator.SetTrigger("FadeOut");
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

    public void LoadMainSceneFromLoss()
    {
        gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            Debug.Log("Script Excecuted");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex - 2);
            Debug.Log("Script Completed");
        }
        else
        {
            Debug.LogError("GameSession not found!");
        }
    }

    public void LoadLossFromMainScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 2);
    }

    public void LoadMainMenu()
    {
        gameSession.ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadBlade()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadKey()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSecondRoom()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        // Only works in built version of game, not in editor
        Debug.Log("Quitting Game");
        Application.Quit(3);
    }

    public void LoadBladeScene()
    {
        SceneManager.LoadScene(6);
    }

    public void BladePuzzleComplete()
    {
        knives++;
        if (knives == 5)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void ExitBladePuzzle()
    {
        SceneManager.LoadScene(5);
    }

    public void Teleporters(int teleportToLocation)
    {
        SceneManager.LoadScene(teleportToLocation);
    }


}