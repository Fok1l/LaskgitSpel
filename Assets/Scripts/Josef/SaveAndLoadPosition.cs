using System.Collections;
using UnityEngine;

public class SaveAndLoadPosition : MonoBehaviour
{
    // Configurable parameters

    // Private variables
    Vector3 originPosition; // For later, currently not used
     Vector3 oldPosition;

    // Cached references
    PlayerMove player;

    void Awake()
    {
        oldPosition = new Vector3(0, 0, 0);
        int numberOfSaveAndLoadPosition = FindObjectsOfType<SaveAndLoadPosition>().Length;

        if (numberOfSaveAndLoadPosition > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();

        originPosition = player.transform.position;
    }

    // When exiting a scene, save the current position
    public void SavePosition()
    {
        player = FindObjectOfType<PlayerMove>();

        oldPosition = player.transform.position;
    }

    // When reloading the scene, go back to the previous position
    public void ResetPosition()
    {
        StartCoroutine(ResetRoutine());
    }

    IEnumerator ResetRoutine()
    {
        player = FindObjectOfType<PlayerMove>();

        yield return new WaitForEndOfFrame();

        player.transform.position = oldPosition;
    }
}