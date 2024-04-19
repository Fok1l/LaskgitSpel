using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wires_end;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;  

    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        // Mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        // Check for nearby connection points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            // Make sure not my own collider
            if (collider.gameObject != gameObject)
            {
                // Update wire to the connection point position
                UpdateWire(collider.transform.position);

                // Check if the wires are same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    // Count connection
                    Main.Instance.SwitchChange(1);
                    // Finish step
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }
        }

        // Update wire
        UpdateWire(newPosition);
    }

    void Done()
    {
        // Turn on light
        lightOn.SetActive(true);

        // Destroy the script
        Destroy(this);
    }

    private void OnMouseUp()
    {
        // Update wire
        UpdateWire(startPosition);
    }
    void UpdateWire(Vector3 newPosition)
    {
        // Update position
        transform.position = newPosition;

        // Update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        // Update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wires_end.size = new Vector2(dist, wires_end.size.y);
    }
}
