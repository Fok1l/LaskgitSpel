using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    //Rigidbody2D childsRigidbody;
    GameSession gameSession;
    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject unlockedDoor;
    [SerializeField] GameObject wontBudgeCanvi;

    private void Start()
    {
        //childsRigidbody = GetComponentInChildren<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
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
        wontBudgeCanvi.SetActive(false);
    }
}
