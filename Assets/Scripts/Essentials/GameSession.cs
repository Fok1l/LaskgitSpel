
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    public bool zapPuzzleKeyGained = false;
    public bool tidningGained = true;
    SceneLoader loader;
    [SerializeField]public Canvas pauseMenuCanvas;
    bool PauseOveride;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        Debug.Log("gameSession found it self");
        pauseMenuCanvas.enabled = false;

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
        pauseMenuCanvas = GameObject.Find("PauseMenu_Canvas").GetComponent<Canvas>();

        if (pauseMenuCanvas == null)
        {
            Debug.LogError("PauseMenu_Canvas not found!");
        }
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
            pauseMenuCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }
}