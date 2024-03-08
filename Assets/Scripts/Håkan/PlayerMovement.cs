using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;

    Rigidbody2D thisRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {

        //the acceleration of the players movement
        thisRigidBody.velocity = new Vector2(horizontal * speed, vertical * speed);
        //thisRigidBody.velocity = new Vector2(horizontal * speed, 0);
        //thisRigidBody.velocity = new Vector2(0, vertical * speed);
    }
}
