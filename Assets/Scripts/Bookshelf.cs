using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bookshelf : MonoBehaviour
{
    public Canvas EPromptCanvas;
    void OnTriggerEnter2D (Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            Debug.Log("Player is by the Shelf");
            EPromptCanvas.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player")
        {
            Debug.Log("Player Leave Shelf");
            EPromptCanvas.enabled = false;
        }
      
    }
}
