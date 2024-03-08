using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRB : MonoBehaviour
{
    [SerializeField] Vector2 screenPosition;
    [SerializeField] Vector2 worldPosition;
    [SerializeField] GameObject bladeSlot;
    [SerializeField] GameObject blade;


    PolygonCollider2D polygonCollider2D;
    ItemSlotCollision slotCollision;
    SceneLoader loader;


    private Vector3 originalPosition;
    private Vector3 originalScale;

    private bool ifollow;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;


        slotCollision = GetComponent<ItemSlotCollision>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        loader = FindObjectOfType<SceneLoader>();

        new Vector2(-1.3f, 7.2f);

        ifollow = false;

    }

    void OnMouseDown()
    {
        Debug.Log("Clicked on the game object: " + gameObject.name);
        ifollow = true;

    }
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (ifollow == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.position = mousePos;
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (Input.GetMouseButtonUp(0))
            {
                ifollow = false;
                transform.localScale = originalScale;
                transform.position = originalPosition;

                Collider2D[] colliders = Physics2D.OverlapPointAll(mouseWorldPos);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("LowerRightSlot") && blade.GetComponent<Collider2D>().enabled) //if mouse is inside the collider: && collider.bounds.Contains(mouseWorldPos)
                    {
                        //snapp to the slot position
                        transform.position = collider.transform.position;
                        blade.GetComponent<Collider2D>().enabled = false;
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        loader.BladePuzzleComplete();

                        break;
                    }
                }
            }
        }
    }
}
