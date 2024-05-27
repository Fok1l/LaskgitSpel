using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    CutsceneManager manager;
    AudioSource soundSource;
    GameObject soundObject;
    [SerializeField] AudioClip TextSound;

    // Static variable to track if dialogue has been shown
    private static bool dialougeShown = false;

    private void Update()
    {
        SkipThroughDialouge();
    }

    void Awake()
    {
        // Create the persistent sound object if it doesn't exist
        if (soundObject == null)
        {
            soundObject = new GameObject("DialougeSoundObject");
            DontDestroyOnLoad(soundObject);
            soundSource = soundObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        manager = FindObjectOfType<CutsceneManager>();

        // Check if dialogue has already been shown in this session
        if (dialougeShown)
        {
            Destroy(gameObject);
        }
        else
        {
            StartDialouge();
        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) // Type text by letter
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            TypeSound();
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Set static variable to mark dialogue as shown
            dialougeShown = true;

            // Destroy the dialogue box
            Destroy(gameObject);
        }
    }

    void SkipThroughDialouge()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void TypeSound()
    {
        soundSource.PlayOneShot(TextSound);
    }
}
