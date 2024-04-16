
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    public bool zapPuzzleKeyGained = false;
    public bool tidningGained = true;
    SceneLoader loader;
    UpperBladeTest upperBladeTest;
    public Canvas PauseCanvas;
    [SerializeField] public bool spawnTheBookPuzzleJar = false;
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

        if(upperBladeTest.theBladeTestIsCompleted == true)
        {
            Debug.Log("IT WORKS!");
            spawnTheBookPuzzleJar = true;
        }


    }

    public void Start()
    {
           loader = FindObjectOfType<SceneLoader>();
        upperBladeTest = FindObjectOfType<UpperBladeTest>();

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