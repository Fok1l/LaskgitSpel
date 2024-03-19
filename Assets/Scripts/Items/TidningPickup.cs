using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidningPickup : MonoBehaviour
{
    FelixMoveTest move;
    // Start is called before the first frame update
    void Start()
    {
        move = FindObjectOfType<FelixMoveTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        move.tidningGained = true;
        Destroy(gameObject);
    }
}
