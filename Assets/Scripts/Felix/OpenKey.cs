using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKey : MonoBehaviour
{
    [SerializeField] SceneLoader loader;
    public Canvas EPromptCanvas;

    void OnTriggerEnter2D(Collider2D EnteringTrigger) //This works, very nice. Don't change
    {
        if (EnteringTrigger.tag == "Player")
        {
            EPromptCanvas.enabled = true;
        }
    }

    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }
    private void OnTriggerStay2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player" && Input.GetKeyUp(KeyCode.E))
        {
            loader.LoadKey();
        }

    }
    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player")
        {
            EPromptCanvas.enabled = false;
        }

    }
}
