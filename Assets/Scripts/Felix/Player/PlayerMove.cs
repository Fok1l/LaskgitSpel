using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;
    PlayerCamera cam;

   // [SerializeField] GameObject flashLightObject;
   // public bool usingFlashLight = false;

    private Vector2 moveInput;
    private Rigidbody2D thisRigidBody;
    private Transform characterTransform;
    [SerializeField] public float StoredX;
    [SerializeField] public float StoredY;
    public bool PlayerCutSceneOveride = false;
   // Animator myAnimator;
   // PlayerAnimations playerAnimations;


    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        characterTransform = transform;
    }

    void Update()
    {
        faceMouse();
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        if (Input.GetKey(KeyCode.G))
        {
            StoredX = transform.position.x;
            StoredY = transform.position.y;
        }
    }

    void faceMouse()
    {
        if (PlayerCutSceneOveride == false)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 direction = new Vector2
            (
                mousePos.x - transform.position.x,
                mousePos.y - transform.position.y
            );

            transform.up = direction;
        }
        else { }
    }

    void MoveCharacter()
    {
        {
            if (PlayerCutSceneOveride == false)
            {
            thisRigidBody.velocity = moveInput * speed;
            }
            else { }
        }
    }






    //void AccessInventory()
    // {
    //     if (!usingFlashLight && Input.GetKeyUp(KeyCode.R))
    //     {
    //unlitFlashLight.gameObject.SetActive(false);
    //       usingFlashLight = true;
    //litFlashLight.gameObject.SetActive(true);
    //        flashLightObject.SetActive(true);
    //    }
    //    else if (usingFlashLight == true && Input.GetKeyUp(KeyCode.R))
    //   {
    //unlitFlashLight.gameObject.SetActive(true);
    //      usingFlashLight = false;
    //litFlashLight.gameObject.SetActive(false);
    //    flashLightObject.SetActive(false);
    //    }
    //}
}

