using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] int teleportTo;
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
        if (EnteringTrigger.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                {
                    loader.Teleporters(teleportTo);
                }
            }
        }
       
    }

    //   private void OnTriggerStay2D(Collider2D EnteringTrigger)
    //  {
    // if (EnteringTrigger.tag == "Player")
    //  {
    //    Scene currentScene = SceneManager.GetActiveScene();

    //    if (Input.GetKey(KeyCode.E) && currentScene.buildIndex == 0)
    //   {
    //       loader.FadeToLevel(1);
    //   }
    //   else
    //{
    //     if (Input.GetKey(KeyCode.E))
    //     {
    //        loader.FadeToLevel(0);
    //    }
    //    }

    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player")
        {
            Debug.Log("Player Leave Door");
            EPromptCanvas.enabled = false;
        }

    }
}
