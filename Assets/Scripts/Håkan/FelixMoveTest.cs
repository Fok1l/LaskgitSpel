using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelixMoveTest : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the input vector to ensure consistent speed
        moveInput.Normalize();

        // Snap the input to the closest cardinal direction
        moveInput = SnapToYX(moveInput);

        rb2d.velocity = moveInput * moveSpeed;
    }

    //This is to snap the movement to only left, right, up, and down. 
    private Vector2 SnapToYX(Vector2 input)
    {
        // Calculate the absolute values for x and y components
        float absX = Mathf.Abs(input.x);
        float absY = Mathf.Abs(input.y);

        // Snap the input to the closest cardinal direction
        if (absX > absY)
        { // Up & Down
            return new Vector2(Mathf.Sign(input.x), 0f);
        } // Left & Right
        else if (absY > absX)
        {
            return new Vector2(0f, Mathf.Sign(input.y));
        }
        else //Acounts for no movement/Fixes bug making the character move up automatically
        {
            return Vector2.zero;
        }
    }
}
