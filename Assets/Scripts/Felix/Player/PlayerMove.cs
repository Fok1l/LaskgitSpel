using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;

    private Vector2 moveInput;
    private Rigidbody2D thisRigidBody;
    private Transform characterTransform;


    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        characterTransform = transform;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = SnapToYX(moveInput);
    }

    private void FixedUpdate()
    {
        thisRigidBody.velocity = moveInput * speed;

        if (moveInput.x > 0) // Moving right (D key)
        {
            characterTransform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else if (moveInput.x < 0) // Moving left (A key)
        {
            characterTransform.rotation = Quaternion.Euler(0, 0, -90f);
        }
        else if (moveInput.y > 0) // Moving up (W key)
        {
            characterTransform.rotation = Quaternion.Euler(0, 0, -180f);
        }
        else if (moveInput.y < 0) // Moving down (S key)
        {
            characterTransform.rotation = Quaternion.Euler(0, 0, 0f);
        }
    }

    private Vector2 SnapToYX(Vector2 input)
    {
        float absX = Mathf.Abs(input.x);
        float absY = Mathf.Abs(input.y);

        if (absX > absY)
        {
            return new Vector2(Mathf.Sign(input.x), 0f);
        }
        else if (absY > absX)
        {
            return new Vector2(0f, Mathf.Sign(input.y));
        }
        else
        {
            return Vector2.zero;
        }
    }
}

