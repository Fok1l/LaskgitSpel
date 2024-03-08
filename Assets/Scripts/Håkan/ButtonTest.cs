using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Transform objectInteraction;
    [SerializeField] Transform objectInteractionReplacement;
    [SerializeField] Transform interactableReplacement;

    [Header("MouseInteraction")]
    //[SerializeField] float minXPos = 1f;
    //[SerializeField] float maxXPos = 16f;
    //[SerializeField] float minYPos = 1f;
    //[SerializeField] float maxYPos = 16f;
    //[SerializeField] float screenWidthInUnits = 16f;

    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            objectInteractionReplacement.transform.position = new Vector2(-14.41f, 3.27f);
            objectInteraction.transform.position = new Vector2(69f, 69f);
            //objectInteraction.transform.position;
            interactableReplacement.transform.position = new Vector2(-21.92f, 2.39f);
            Destroy(gameObject);
        }
    }
}
