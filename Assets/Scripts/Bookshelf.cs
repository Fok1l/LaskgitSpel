using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Bookshelf : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas InvCanvas;
    void OnTriggerEnter2D (Collider2D EnteringTrigger)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            InvCanvas.enabled = true;
        }
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
            InvCanvas.enabled = false;
        }
      
    }
}
