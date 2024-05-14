using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSystem : MonoBehaviour
{
    PlayerMove player;
    [SerializeField] AudioClip paperSound;
    public Image[] noteImages; // Array of note UI Images
    bool[] isOpen; // Array of bools to track if a note is open
    [SerializeField] GameObject[] papers; // Array of paper GameObjects

    void Start()
    {
       // audioManager = GetComponent<AudioManager>(); 
        player = FindObjectOfType<PlayerMove>();

        // Disable all note images initially
        foreach (Image noteImage in noteImages)
        {
            noteImage.enabled = false;
        }

        isOpen = new bool[noteImages.Length];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int paperIndex = -1;
            for (int i = 0; i < papers.Length; i++)
            {
                if (papers[i] == gameObject)
                {
                    paperIndex = i;
                    break;
                }
            }

            if (paperIndex != -1 && !noteImages[paperIndex].enabled)
            {
                noteImages[paperIndex].enabled = true;
                isOpen[paperIndex] = true;
                PlayPaperSFX();
                papers[paperIndex].SetActive(false); // Deactivate the paper GameObject
                Destroy(papers[paperIndex], 1f); // Destroy the paper GameObject after 1 second
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            for (int i = 0; i < noteImages.Length; i++)
            {
                if (noteImages[i].enabled)
                {
                    // Open the UI for the respective paper
                    TogglePaperUI(i);
                    break;
                }
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            for (int i = 0; i < noteImages.Length; i++)
            {
                if (isOpen[i])
                {
                    // Close the UI for the respective paper
                    TogglePaperUI(i);
                    break;
                }
            }
        }
    }

    void TogglePaperUI(int paperIndex)
    {
        isOpen[paperIndex] = !isOpen[paperIndex];
        noteImages[paperIndex].enabled = isOpen[paperIndex];

        if (isOpen[paperIndex])
        {
            Debug.Log("Opening UI for Paper " + paperIndex);
        }
        else
        {
            Debug.Log("Closing UI for Paper " + paperIndex);
        }
    }

    void PlayPaperSFX()
    {
        AudioSource.PlayClipAtPoint(paperSound, Camera.main.transform.position);
    }
}