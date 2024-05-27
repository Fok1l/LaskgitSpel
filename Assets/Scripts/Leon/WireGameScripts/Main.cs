using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main Instance;
    public GameObject winText;
    [SerializeField] GameObject explainText;
    [SerializeField] GameObject continueButton;

    public int SwitchCount;
    private int onCount = 0;

    GameSession gameSession;
    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        gameSession = FindObjectOfType<GameSession>();
        Instance = this;
    }

    public void SwitchChange(int points) { 
    onCount = onCount + points;
        if (onCount == SwitchCount)
        {
            gameSession.wirePuzzleComplete = true;
            winText.SetActive(true);
            explainText.SetActive(true);
            continueButton.SetActive(true);
            playerMove.playerFirstTimeSpawn = false;
        }
    }
}
