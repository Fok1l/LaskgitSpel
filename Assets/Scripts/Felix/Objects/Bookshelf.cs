using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas InvCanvas;
    bool BookStay = false; // BookStay bool as a repalcer for ontriggerstay
    public bool SpawnAJar = false; //To spawn the jar for the puzzle
 
    private void OnTriggerStay2D(Collider2D EnteringTrigger) //Works. Needs to be OnTriggerStay2d, otherwise won't work.
    {
        if (BookStay == false && EnteringTrigger.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            InvCanvas.enabled = true;
            BookStay = true;
            EPromptCanvas.enabled = false;

        }
    }

    private void FixedUpdate()
    {
        if (BookStay == true && Input.GetKey(KeyCode.E)) 
        {
            InvCanvas.enabled = true;
            EPromptCanvas.enabled = false;
            SpawnAJar = true;
        }
    }

    public void CloseMenuButStay()
    {
        InvCanvas.enabled = false;
        EPromptCanvas.enabled = true;
    }

  
    void OnTriggerEnter2D (Collider2D EnteringTrigger) //This works, very nice. Don't change
    {
        if (EnteringTrigger.tag == "Player")
        {
            BookStay = true;
            EPromptCanvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D ExitTrigger) //This works (Probally)
    {
        if (ExitTrigger.tag == "Player")
        {
            BookStay = false;
            EPromptCanvas.enabled = false;
            InvCanvas.enabled = false;
        }
      
    }
}
