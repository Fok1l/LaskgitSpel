using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAndClose : MonoBehaviour
{
    [Header("Objects & Bools")]
    [SerializeField] GameObject closedDoor;
    [SerializeField] Vector3 doorRotation;
    [SerializeField] Vector3 doorPosition;
    [SerializeField] Vector3 originalPosition;
    [SerializeField] Vector3 originalRotation;
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
            closedDoor.transform.position = doorPosition;
            closedDoor.transform.Rotate(doorRotation);
        }else if (AtTheDoor = true && Input.GetKeyDown(KeyCode.E) && closedDoor.activeSelf == false && doorOpen == true)
        {
            PlayDoorSFX();
            closedDoor.transform.position = originalPosition;
            closedDoor.transform.Rotate(originalRotation);
            CloseOpenDoor();
        }
        else if (AtTheDoor = true && Input.GetKeyDown(KeyCode.E) && closedDoor.activeSelf == false && doorOpen == true)
        {
            CloseOpenDoor();
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

    void CloseOpenDoor()
    {
        PlayDoorSFX();
        closedDoor.SetActive(true);
    }
}
