using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPuzzlePiece : MonoBehaviour
{

    [SerializeField] GameObject piece1;
    // Start is called before the first frame update
    void Start()
    {
        piece1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            piece1.SetActive(true);
            Destroy(gameObject);

        }
    }
}
