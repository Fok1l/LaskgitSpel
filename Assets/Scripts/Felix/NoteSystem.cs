using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSystem : MonoBehaviour
{
    PlayerMove player;
    public Image Note1;
    public bool NoteObject1 = false;

    [SerializeField] GameObject Paper1;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NoteObject1 = true;
            Note1.enabled = true;
            Destroy(gameObject);
        }
    }
}
