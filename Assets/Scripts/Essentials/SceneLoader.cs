using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameSession gameSession;
    public Animator animator;
    private int leveltoload;
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


    // Everything below this might be completely useless, but I'm saving it just incase. But our new level load system feels miles easier to use.

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
            gameSession.ResetCollectible();
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

    public void LoadGameOver()
    {
        gameSession.ResetGame();
        SceneManager.LoadScene(3);
    }

    public void LoadMainScene()
    {
        gameSession.ResetGame();
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        // Only works in built version of game, not in editor
        Debug.Log("Quitting Game");
        Application.Quit();
    }


}