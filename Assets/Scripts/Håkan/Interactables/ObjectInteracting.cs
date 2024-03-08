using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteracting : MonoBehaviour
{
    [SerializeField] int amountToDecreaseDynamite = 1;

    SidescrollerMovement player;
    MouseClick mouseClick;

    [SerializeField] GameObject DynamiteObject;

    Keycard keycard;
    // Start is called before the first frame update
    void Start()
    {
        keycard = GetComponent<Keycard>();
        player = GetComponent<SidescrollerMovement>();
        mouseClick = GetComponent<MouseClick>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (keycard.keycardAccuired == true)
        //{
        //    requiredItemAccuired |= true;
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            //mouseClick.DecreaseDynamiteAmount(amountToDecreaseDynamite);
        }
    }
}
