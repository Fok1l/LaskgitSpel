using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSystem : MonoBehaviour
{
    PlayerMove player;

    public Image[] noteImages; // Array of note UI Images
    public bool[] noteObjects; // Array of boolean flags for each note (Helps in enbaling/disabling ui and papers)

    [SerializeField] GameObject[] papers; // Array of paper GameObjects

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();

        // Disable all note images initially
        foreach (Image noteImage in noteImages)
        {
            noteImage.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the index of the first available note slot
            int noteIndex = -1;
            for (int i = 0; i < noteObjects.Length; i++)
            {
                if (!noteObjects[i])
                {
                    noteIndex = i;
                    break;
                }
            }

            if (noteIndex != -1)
            {
                noteObjects[noteIndex] = true;
                noteImages[noteIndex].enabled = true;
                papers[noteIndex].SetActive(false); // Deactivate the paper GameObject
                Destroy(papers[noteIndex], 1f); // Destroy the paper GameObject after 1 second
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            for (int i = 0; i < noteImages.Length; i++)
            {
                if (noteObjects[i] && noteImages[i].enabled)
                {
                    // Open the UI for the respective paper
                    OpenPaperUI(i);
                    break;
                }
            }
        }
    }

    void OpenPaperUI(int paperIndex)
    {
        // Implement the logic to open the UI for the respective paper
        Debug.Log("Opening UI for Paper " + paperIndex);
    }
}
