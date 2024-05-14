using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    PlayerSpawner playerSpawner;
    GameSession gameSession;
    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject unlockedDoor;
    [SerializeField] GameObject wontBudgeCanvi;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        playerSpawner = FindObjectOfType<PlayerSpawner>();
    }

    private void FixedUpdate()
    {
        if (gameSession.zapPuzzleKeyGained == true)
        {
            gameObject.transform.GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerEnter2D(Collider2D enterDoor)
    {
        if (gameSession.zapPuzzleKeyGained == false)
        {
            wontBudgeCanvi.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D exitDoor)
    {
        if (wontBudgeCanvi != null)
        {
            wontBudgeCanvi.SetActive(false);
        }
    }
}
