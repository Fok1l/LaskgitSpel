using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;

    [SerializeField] GameObject flashLightObject;
    public bool usingFlashLight = false;

    private Vector2 moveInput;
    private Rigidbody2D thisRigidBody;
    private Transform characterTransform;

    Animator myAnimator;
    PlayerAnimations playerAnimations;


    void Start()
    {
        myAnimator = GetComponent<Animator>();
        thisRigidBody = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        characterTransform = transform;
    }

    void Update()
    {
        playerAnimations.WalkingAnim();
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = SnapToYX(moveInput);
        AccessInventory();
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

    void AccessInventory()
    {
        if (!usingFlashLight && Input.GetKeyUp(KeyCode.R))
        {
            //unlitFlashLight.gameObject.SetActive(false);
            usingFlashLight = true;
            //litFlashLight.gameObject.SetActive(true);
            flashLightObject.SetActive(true);
        }
        else if (usingFlashLight == true && Input.GetKeyUp(KeyCode.R))
        {
            //unlitFlashLight.gameObject.SetActive(true);
            usingFlashLight = false;
            //litFlashLight.gameObject.SetActive(false);
            flashLightObject.SetActive(false);
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

