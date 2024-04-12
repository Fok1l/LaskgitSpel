using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Quest")]
    [SerializeField] GameObject uiBook;
    public bool usingBook = false;
    //[SerializeField] GameObject openBook;
    //[SerializeField] GameObject closeBook;

    [Header("Inventory")]
    bool invActive = false;
    public Canvas Inventory_Canvas;


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
    public bool PlayerCutSceneOveride = false;
    // Animator myAnimator;
    // PlayerAnimations playerAnimations;
    public float storedX;
    public float storedY;
    private PlayerPositionManager positionManager;


    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        characterTransform = transform;
        positionManager = GameObject.FindObjectOfType<PlayerPositionManager>();
        if (positionManager == null)
        {
            // Create a new PlayerPositionManager object
            GameObject managerObject = new GameObject("PlayerPositionManager");
            positionManager = managerObject.AddComponent<PlayerPositionManager>();
        }

    }

    void Update()
    {

        faceMouse();
        UseFlashlight();
        AccessQuestBook();
        AccessInventory();
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        MoveCharacter();
        if (Input.GetKeyDown(KeyCode.G))
        {
            FetchPlayerPosition();
        }

        if (Input.GetKey(KeyCode.H))
        {
            Vector3 storedPosition = positionManager.RetrievePosition();
            if (storedPosition != Vector3.zero)
            {
                Debug.Log("1Log" + storedPosition);
                // Teleport the player to the stored position
                TeleportToPosition(storedPosition);
                Debug.Log("2Log" + storedPosition);
                // Clear the stored position
                positionManager.StorePosition(Vector3.zero);
            }
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

    void TeleportPlayerToStoredPosition() // Big ass function to be able to teleport the player on demand
    {

        positionManager = FindObjectOfType<PlayerPositionManager>();
        characterTransform = transform;

        // Check if there is a stored position
        Vector3 storedPosition = positionManager.RetrievePosition();
        if (storedPosition != Vector3.zero)
        {
            // Teleport player to stored position
            characterTransform.position = storedPosition;

            // Clear stored position
            positionManager.StorePosition(Vector3.zero);

        }

    }
    private void FetchPlayerPosition()
    {
        Vector3 currentPlayerPosition = characterTransform.position;
        Debug.Log("Player Position: " + currentPlayerPosition);
    }

    private void TeleportToPosition(Vector3 targetPosition)
    {
        characterTransform.position = targetPosition;
    }







    /// <summary>
    /// H�KAN SAKER
    /// </summary>
    void UseFlashlight()
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

    void AccessInventory()
    {
        if (invActive == false && Input.GetKeyDown(KeyCode.I))
        {
            //invCanvas.SetActive(true);
            Inventory_Canvas.gameObject.SetActive(true);
            invActive = true;
        }
        else if (invActive == true && Input.GetKeyDown(KeyCode.I))
        {
            //invCanvas.SetActive(false);
            Inventory_Canvas.gameObject.SetActive(false);
            invActive = false;
        }
    }
}
