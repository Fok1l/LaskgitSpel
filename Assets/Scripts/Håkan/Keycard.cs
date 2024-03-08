using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    SidescrollerMovement player;

    public bool keycardAccuired = false;

    [SerializeField] GameObject DynamiteObject;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SidescrollerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            keycardAccuired = true;
            player.HahaIHaveKeycardNow();
            Destroy(gameObject);
        }
    }
}
