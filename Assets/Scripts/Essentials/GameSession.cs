
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    public bool zapPuzzleKeyGained = false;
    public bool tidningGained = true;
    SceneLoader loader;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        Debug.Log("gameSession found it self");

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

    public void Start()
    {
           loader = FindObjectOfType<SceneLoader>();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("QuitGame");
        }
    }
}