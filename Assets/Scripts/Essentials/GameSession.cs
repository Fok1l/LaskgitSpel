
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    public bool zapPuzzleKeyGained = false;
    public bool tidningGained = true;
    SceneLoader loader;
    public Canvas PauseCanvas;
    bool PauseOveride;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        Debug.Log("gameSession found it self");
        PauseCanvas.enabled = false;

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
            PauseOveride = true;
            PauseCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }
}