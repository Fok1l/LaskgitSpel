using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWirePuzzle : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] int teleportTo;
    [SerializeField] SceneLoader loader;
    public Canvas EPromptCanvas;
    bool AtTheDoor = false;
    [SerializeField] AudioClip doorSound;
    [SerializeField] GameObject wirePuzzle;

    GameSession gameSession;
    PlayerMove player;
    GameObject soundObject; // Reference to the persistent sound object
    AudioSource soundSource; // Reference to the AudioSource component
    Animator animator;
    Canvas FadeCanvas;

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

    void OnTriggerEnter2D(Collider2D EnteringTrigger)
    {
        if (EnteringTrigger.tag == "Player")
        {
            AtTheDoor = true;
            EPromptCanvas.enabled = true;
        }
    }

    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        if (AtTheDoor && Input.GetKey(KeyCode.E))
        {
            wirePuzzle.SetActive(true);
            playerMove.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D ExitTrigger)
    {
        if (ExitTrigger.tag == "Player")
        {
            Debug.Log("Player Leave Door");
            AtTheDoor = false;

            if (EPromptCanvas != null)
            {
                EPromptCanvas.enabled = false;
            }
        }
    }
}
