using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBlade : MonoBehaviour
{
    [SerializeField] SceneLoader loader;
    public Canvas EPromptCanvas;
    bool AtBladeTable = false;
    [SerializeField] int teleportTo;

    GameSession gameSession;


    void OnTriggerEnter2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            AtBladeTable = true;
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
        if (AtBladeTable == true && Input.GetKey(KeyCode.E))
        {
            gameSession.playerSpawnPosition = loader.player.transform.position;
            loader.dontActivateTimer = false;
            loader.Teleporters(teleportTo);
        }
    }

    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player")
        {
            AtBladeTable = false;
            EPromptCanvas.enabled = false;
        }

    }
}
