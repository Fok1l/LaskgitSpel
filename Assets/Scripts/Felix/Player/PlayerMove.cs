using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;


    Camera mainCam;
    [SerializeField] private float maxXpos;
    [SerializeField] private float maxYpos;
    [SerializeField] private float minXpos;
    [SerializeField] private float minYpos;

    private Vector2 moveInput;

    Rigidbody2D thisRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = SnapToYX(moveInput);
    }

    private void FixedUpdate()
    {

        //the acceleration of the players movement
        thisRigidBody.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
        //thisRigidBody.velocity = new Vector2(horizontal * speed, 0);
        //thisRigidBody.velocity = new Vector2(0, vertical * speed);
    }

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

