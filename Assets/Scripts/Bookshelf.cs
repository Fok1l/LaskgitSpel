using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Bookshelf : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas InvCanvas;
    bool BookStay; // Use This Bool next time, to try and get a better working bookshelf (Like if BookShelfStay == True)

    private void OnTriggerStay2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E)) //&& InvCanvas.enabled == false)
            {
                Debug.Log("Open Bookshlf Inv");
                InvCanvas.enabled = true;
            }
            //if (//Input.GetKey(KeyCode.E) InvCanvas.enabled == true)
           // { 
           //     //InvCanvas.enabled = false;
           // }
        }
    }

    void OnTriggerEnter2D (Collider2D EnteringTrigger) //My brother in christ what is the error
    {
        if (EnteringTrigger.tag == "Player")
        {
            Debug.Log("Player by Shelf");
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
