using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKey : MonoBehaviour
{
    [SerializeField] SceneLoader loader;
    public Canvas EPromptCanvas;
    bool AtKeyTable = false;
    [SerializeField] int teleportTo;

    GameSession gameSession;


    void OnTriggerEnter2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            AtKeyTable = true;
            EPromptCanvas.enabled = true;
        }
    }
    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void FixedUpdate()
    {
        if (AtKeyTable == true && Input.GetKey(KeyCode.E))
        {
            loader.dontActivateTimer = false;
            loader.Teleporters(teleportTo);
        }
    }

    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player" && EPromptCanvas != null)
        {
            AtKeyTable = false;
            EPromptCanvas.enabled = false;
        }
        else if (ExitTrigger.tag == "Player")
        {
            AtKeyTable = false;
        }

    }
}
