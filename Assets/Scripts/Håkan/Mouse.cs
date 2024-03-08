using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] Vector2 screenPosition;
    [SerializeField] Vector2 worldPosition;
    [SerializeField] GameObject bladeSlot;
    [SerializeField] GameObject mouse;


    CircleCollider2D circleCollider;
    ItemSlotCollision slotCollision;
    UpperBladeTest upperBladeTest;


    private Vector3 originalPosition;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;


        slotCollision = GetComponent<ItemSlotCollision>();
        circleCollider = GetComponent<CircleCollider2D>();
        mouse = GetComponent<GameObject>();
        upperBladeTest = GetComponent<UpperBladeTest>();

        new Vector2(-1.3f, 7.2f);

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
            RaycastHit2D pieces = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(pieces);
        

            // Increase size to 0.75 when pressing left mouse button
            transform.localScale = new Vector3(0.25f, 0.25f, 1f);
        



            Collider2D[] colliders = Physics2D.OverlapPointAll(mouseWorldPos);
            

            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.position = mousePos;

            //Increase size wile following the mouse
            transform.localScale = new Vector3(0.25f, 0.25f, 1f);



        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ULB"))
        {
            Debug.Log("Enter collider with tag" + other.tag);
        }
    }
}