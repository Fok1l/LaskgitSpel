using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSystem : MonoBehaviour
{
    PlayerMove player;

    public Image[] noteImages; // Array of note UI Images

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
                papers[paperIndex].SetActive(false); // Deactivate the paper GameObject
                Destroy(papers[paperIndex], 1f); // Destroy the paper GameObject after 1 second
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            for (int i = 0; i < noteImages.Length; i++)
            {
                if (noteImages[i].enabled)
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
