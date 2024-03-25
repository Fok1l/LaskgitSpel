using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] int teleportTo;
    [SerializeField] SceneLoader loader;
    [SerializeField] GameObject kitchenDoor;
    [SerializeField] GameObject unlockedDoor;
    public Canvas EPromptCanvas;

    GameSession gameSession;


    void OnTriggerEnter2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            EPromptCanvas.enabled = true;
        }
    }
    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }


    private void OnTriggerStay2D(Collider2D EnteringTrigger)
    {
        //if (gameSession.zapPuzzleKeyGained == true && gameObject == kitchenDoor && Input.GetKeyUp(KeyCode.E))
        //{
          //  loader.LoadKitchen();
        //}
        if (EnteringTrigger.tag == "Player" && Input.GetKeyUp(KeyCode.E) && gameObject == unlockedDoor)
        {
            loader.Teleporters(teleportTo);

        }

    }

    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {

        if (ExitTrigger.tag == "Player")
        {
            Debug.Log("Player Leave Door");
            EPromptCanvas.enabled = false;
        }

    }
}
