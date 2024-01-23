using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // "GetAxisRaw" gets the position of x (y in the one below), and sets the cordinate of the moveinput to that
        moveInput.y = Input.GetAxisRaw("Vertical");


        moveInput.Normalize(); //Make it move at a consitent speed
        rb2d.velocity = moveInput * moveSpeed;

    }
}
    
        
    