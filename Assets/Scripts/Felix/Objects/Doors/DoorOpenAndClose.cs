using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAndClose : MonoBehaviour
{
    [Header("Objects & Bools")]
    [SerializeField] GameObject opendDoor;
    [SerializeField] GameObject closedDoor;
    bool doorOpen = false;
    bool AtTheDoor = false;
    public Canvas EPromptCanvas;
    SceneLoader loader;

    [Header("Sounds")]
    [SerializeField] AudioClip doorSound;
    GameObject soundObject; // Reference to the persistent sound object
    AudioSource soundSource; // Reference to the AudioSource component

    void Awake()
    {
        // Create the persistent sound object if it doesn't exist
        if (soundObject == null)
        {
            soundObject = new GameObject("DoorSoundObject");
            DontDestroyOnLoad(soundObject);
            soundSource = soundObject.AddComponent<AudioSource>();
        }
    }
    void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AtTheDoor = true && Input.GetKeyDown(KeyCode.E) && closedDoor.activeSelf == true && doorOpen == true)
        {
            PlayDoorSFX();
            closedDoor.SetActive(false);
            opendDoor.SetActive(true);
        }else if (AtTheDoor = true && Input.GetKeyDown(KeyCode.E) && closedDoor.activeSelf == false && doorOpen == true)
        {
            PlayDoorSFX();
            closedDoor.SetActive(true);
            opendDoor.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            AtTheDoor = true;
            EPromptCanvas.enabled = true;
            doorOpen = true;
        }
    }


    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player")
        {
            Debug.Log("Player Leave Door");
            AtTheDoor = false;
            closedDoor.SetActive(true);
            opendDoor.SetActive(false);
            doorOpen = false;
            if (EPromptCanvas != null)
            {
                EPromptCanvas.enabled = false;
            }
        }
    }

    void PlayDoorSFX()
    {
        soundSource.PlayOneShot(doorSound);
    }
}
