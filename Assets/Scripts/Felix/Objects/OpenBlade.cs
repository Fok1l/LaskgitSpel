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

    SaveAndLoadPosition saveAndLoad;

    public void Start()
    {
        saveAndLoad = FindObjectOfType<SaveAndLoadPosition>();

        loader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            AtBladeTable = true;
            EPromptCanvas.enabled = true;
        }
    }

    private void Update()
    {
        if (AtBladeTable == true && Input.GetKey(KeyCode.E))
        {
            loader.dontActivateTimer = false;
            //saveAndLoad.SavePosition();
            loader.LoadNextScene();
        }
    }

    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player" && EPromptCanvas != null)
        {
            AtBladeTable = false;
            EPromptCanvas.enabled = false;
        }
        else if (ExitTrigger.tag == "Player")
        {
            AtBladeTable = false;
        }

    }
}
