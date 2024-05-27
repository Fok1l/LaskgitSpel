using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{
    PlayerMove playerMove;
    CutsceneManager cutsceneManager;
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        cutsceneManager = FindObjectOfType<CutsceneManager>();
    }

    public void DisableMenuCanvas()
    {
        playerMove.menuCanvas.SetActive(false);
        cutsceneManager.Overide = false;
        Time.timeScale = 1f;
    }
}
