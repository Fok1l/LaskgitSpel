using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    PlayerMove player;

    public bool Collectible1Collected = false;

    [SerializeField] GameObject CollectibleObject;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ;
        {
            Collectible1Collected = true;
            Destroy(gameObject);
            player.tag = "Collectible1";
        }
    }
}
