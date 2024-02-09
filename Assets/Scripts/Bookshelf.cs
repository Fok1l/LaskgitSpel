using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Bookshelf : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas InvCanvas;
    bool BookStay; // BookStay bool as a repalcer for ontriggerstay (Hopefully)
    
    private void OnTriggerStay2D(Collider2D EnteringTrigger) //Works, but needs to be OnTriggerStay2d, otherwise won't work.
    {
        if (EnteringTrigger.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && BookStay == false)
            {
                InvCanvas.enabled = true;
                BookStay = true;
                EPromptCanvas.enabled = false;
            }
            
        }
    }

  
    void OnTriggerEnter2D (Collider2D EnteringTrigger) //This works, very nice. Don't change
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
            BookStay = false;
            Debug.Log("Player Leave Shelf");
            EPromptCanvas.enabled = false;
            InvCanvas.enabled = false;
        }
      
    }
}
