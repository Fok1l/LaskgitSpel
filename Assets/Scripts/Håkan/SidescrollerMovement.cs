using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollerMovement : MonoBehaviour
{

    [Header("Movement")]
    float horizontal;
    [SerializeField] float walkSpeed = 5f;
    //[SerializeField] float runSpeed = 20f;
    //[SerializeField] float jumpSpeed = 5f;
    [SerializeField] public float iHaveKeycard = 0f;

    Rigidbody2D myRigidBody;
    public BoxCollider2D feetCollider;
    DoorTest door;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        door = GetComponent<DoorTest>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        OnRun();
        OnGravity();
    }

    void OnGravity()
    {
        if(feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) //&& Input.GetKeyDown(KeyCode.LeftShift))
        {
            myRigidBody.velocity = new Vector2(horizontal * walkSpeed, 0);
        }

             // THIS IS IF THE PLAYER WILL FALL!

        //else
        //{
            //myRigidBody.velocity = new Vector2(horizontal * walkSpeed, -9.81f);
        //}
        
    }

    void OnRun()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    walkSpeed = runSpeed;
        //}else
        //{
        //    walkSpeed = 5f;
        //}
    }

    public void HahaIHaveKeycardNow()
    {
        iHaveKeycard = 1f;
        //door.HahaOpenSesame();
    }
}
