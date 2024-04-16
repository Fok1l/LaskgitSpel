using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireMovement : MonoBehaviour
{
    public SpriteRenderer wires_end;
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

        // Update wire
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
