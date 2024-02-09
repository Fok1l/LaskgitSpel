using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Canvas EPromptCanvas;

    void OnTriggerEnter2D(Collider2D EnteringTrigger) //This works, very nice. Don't change
    {
        if (EnteringTrigger.tag == "Player")
        {
            EPromptCanvas.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D ExitTrigger) //This works (Probally)
    {
        if (ExitTrigger.tag == "Player")
        {
            Debug.Log("Player Leave Door");
            EPromptCanvas.enabled = false;
        }

    }
}
