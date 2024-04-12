using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;
    PlayerCamera cam;

    /// <summary>
    /// Inventory Stuff
    /// </summary>
    [Header("Inventory & Flashlight")]
    public bool usingFlashLight = false;
    //[SerializeField] GameObject unlitFlashLight;
    //[SerializeField] GameObject litFlashLight;
    [SerializeField] GameObject flashLightObject;

    [Header("Quest Book")]
    [SerializeField] GameObject uiBook;
    public bool usingBook = false;
    //[SerializeField] GameObject openBook;
    //[SerializeField] GameObject closeBook;


    /// <summary>
    /// BASE
    /// </summary>
    private Vector2 moveInput;
    private Rigidbody2D thisRigidBody;
    private Transform characterTransform;


    /// <summary>
    /// Felix Stuff
    /// </summary>
    [Header("Doors & Cutscene")]
    [SerializeField] public float StoredX;
    [SerializeField] public float StoredY;
    public bool PlayerCutSceneOveride = false;
    private string playerXKey = "PlayerX";
    private string playerYKey = "PlayerY";
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
        AccessInventory();
        AccessQuestBook();
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

    void TeleportPlayerToStoredPos()
    {

        if (PlayerPrefs.HasKey(playerXKey) && PlayerPrefs.HasKey(playerYKey))
        {
            // Retrieve the stored X and Y positions
            float storedX = PlayerPrefs.GetFloat(playerXKey);
            float storedY = PlayerPrefs.GetFloat(playerYKey);

            // Teleport the player to the stored position
            characterTransform.position = new Vector3(storedX, storedY, characterTransform.position.z);

            // Clear the stored position
            PlayerPrefs.DeleteKey(playerXKey);
            PlayerPrefs.DeleteKey(playerYKey);

        }
    }







    /// <summary>
    /// H�KAN SAKER
    /// </summary>
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

    void AccessQuestBook()
    {
        if (!usingBook && Input.GetKeyDown(KeyCode.M))
        {
            uiBook.gameObject.SetActive(true);
            usingBook = true;
            //closeBook.gameObject.SetActive(false);
            //openBook.gameObject.SetActive(true);
        }
        else if (usingBook == true && Input.GetKeyDown(KeyCode.M))
        {
            uiBook.gameObject.SetActive(false);
            usingBook = false;
            //openBook.gameObject.SetActive(false);
            //closeBook.gameObject.SetActive(true);
        }
    }
}

