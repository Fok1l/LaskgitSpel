using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDrag : MonoBehaviour
{
    GameObject blade;
    private Transform draggingPiece = null;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 slotPosition = new Vector3(-1.3f, 2.6f, 0f);
        originalPosition = transform.position;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                //Everything is now movable
                draggingPiece = hit.transform;
            }
        }

        //Stop following the mouse
        if(draggingPiece && Input.GetMouseButtonUp(0))
        {
            if (gameObject.CompareTag("UpperLeftSlot") && blade.GetComponent<Collider2D>().enabled)
            {
                SnapNDisable();
                draggingPiece = null;
                
            }else
            {
                draggingPiece = null;
                transform.position = originalPosition;
                transform.localScale = originalScale;
            }
            
        }

        //Set the piece position to the mouse
        if(draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = draggingPiece.position.z;
            draggingPiece.position = newPosition;
            transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        }
    }

    void SnapNDisable()
    {

    }
}