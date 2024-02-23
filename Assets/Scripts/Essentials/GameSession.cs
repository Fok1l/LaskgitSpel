
using TMPro;
using UnityEngine;


public class GameSession : MonoBehaviour
{

    [SerializeField] int AddCollectible = 1;
    [SerializeField] TextMeshProUGUI Collectible;
    [SerializeField] int currentcollectibles = 0;

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

    private void Start()
    {
        Collectible.text = currentcollectibles.ToString(); //Ignore error temporarly, this is not used for anything right now anyway.
    }

    public void AddtoCollectible()
    {
        currentcollectibles += AddCollectible;
        Collectible.text = currentcollectibles.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public int GetCollectibles()
    {
        return currentcollectibles;
    }

    public void ResetCollectible()
    {
        Debug.Log("Reset excecuted");
        currentcollectibles = 0;
    }
}