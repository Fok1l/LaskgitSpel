using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    Rigidbody2D childsRigidbody;
    GameSession gameSession;

    private void Start()
    {
        childsRigidbody = GetComponentInChildren<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void FixedUpdate()
    {
        if (gameSession.zapPuzzleKeyGained == true)
        {
            //childsRigidbody.bodyType;
        }
    }


}
