using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidningPickup : MonoBehaviour
{
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameSession.tidningGained = true;
        Destroy(gameObject);
    }
}
