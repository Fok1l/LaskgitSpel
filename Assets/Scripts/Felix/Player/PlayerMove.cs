using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
//Comment to fix fork
public class PlayerMove : MonoBehaviour
{

    PlayerSpawner playerSpawner;

    // Move this out of my folder, everyones already modifed this.

    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;
    public CutsceneManager CutsceneManager;

    /// <summary>
    /// Inventory Stuff
    /// </summary>
    [Header("Inventory & Flashlight")]
    public bool usingFlashLight = false;
    [SerializeField] GameObject flashLightObject;

    public GameObject menuCanvas;

    [Header("Quest")]
    [SerializeField] GameObject uiBook;
    [SerializeField] GameObject tutorialText;
    public bool usingBook = false;
    SaveTheBladeBool saveTheBladeBool;
    //[SerializeField] GameObject openBook;
    //[SerializeField] GameObject closeBook;

    [Header("Inventory")]
    //bool invActive = false;
    public Canvas Inventory_Canvas;


    /// <summary>
    /// BASE
    /// </summary>
    private Vector2 moveInput;
    private Rigidbody2D thisRigidBody;
    private Transform characterTransform;


    public bool playerFirstTimeSpawn = false;


    /// <summary>
    /// Felix Stuff
    /// </summary>
    [Header("Doors & Cutscene")]
    // Animator myAnimator;
    // PlayerAnimations playerAnimations;
    public float storedX;
    public float storedY;
    private PlayerPositionManager positionManager;
    private AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip FlashLightClick;


    void Start()
    {
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
        thisRigidBody = GetComponent<Rigidbody2D>();
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        characterTransform = transform;
        positionManager = GameObject.FindObjectOfType<PlayerPositionManager>();
        CutsceneManager = GameObject.FindObjectOfType<CutsceneManager>();
        if (positionManager == null)
        {
            // Create a new PlayerPositionManager object
            GameObject managerObject = new GameObject("PlayerPositionManager");
            positionManager = managerObject.AddComponent<PlayerPositionManager>();
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuCanvas.SetActive(true);
            CutsceneManager.Overide = true;
            Time.timeScale = 0f;
        }

        if (saveTheBladeBool.theBladeTestIsCompleted == true && gameObject.transform.position == new Vector3(16.90145f, 2.37239f))
        {
            gameObject.transform.position = new Vector3(-1.161062f, 10.27668f);
        }

        if (playerFirstTimeSpawn == false)
        {
            gameObject.transform.position = playerSpawner.playerSpawnPosition;
            playerFirstTimeSpawn = true;
        }
        faceMouse();
        UseFlashlight();
        //DestroyTheTutorialText();
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        MoveCharacter();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
                // if (Input.GetKeyDown(KeyCode.G))
                //{
                //     FetchPlayerPosition();
                // }

                // if (Input.GetKey(KeyCode.H))
                //{
                //     Vector3 storedPosition = positionManager.RetrievePosition();
                //     if (storedPosition != Vector3.zero)
                //      {
                //        Debug.Log("1Log" + storedPosition);
                // Teleport the player to the stored position
                //        TeleportToPosition(storedPosition);
                //      Debug.Log("2Log" + storedPosition);
                // Clear the stored position
                //    positionManager.StorePosition(Vector3.zero);
                // }
                //  }
                // }

          void faceMouse()
         {
            if (CutsceneManager.Overide == false)
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
                if (CutsceneManager.Overide == false)
                {
                    thisRigidBody.velocity = moveInput * speed;
                }
                else { audioSource.enabled = false; }
            }
        }
        // private void FetchPlayerPosition()
        // {
        //     Vector3 currentPlayerPosition = characterTransform.position;
        //     Debug.Log("Player Position: " + currentPlayerPosition);
        // }

        //private void TeleportToPosition(Vector3 targetPosition)
        // {
        //     characterTransform.position = targetPosition;
        // }

        





        /// <summary>
        /// H�KAN SAKER
        /// </summary>
        /// 

        void UseFlashlight()
        {
            if (!usingFlashLight && Input.GetKeyUp(KeyCode.F))
            {
                usingFlashLight = true;
                PlayFlashLightClickSFX();
                flashLightObject.SetActive(true);
            }
            else if (usingFlashLight == true && Input.GetKeyUp(KeyCode.F))
            {
                usingFlashLight = false;
                PlayFlashLightClickSFX();
                flashLightObject.SetActive(false);
            }
        }

        void PlayFlashLightClickSFX()
        {
            audioSource.PlayOneShot(FlashLightClick);
        }

        void AccessQuestBook()
        {
            if (!usingBook && Input.GetKeyDown(KeyCode.T))
            {
                uiBook.gameObject.SetActive(true);
                usingBook = true;
                saveTheBladeBool.tutorialText = true;
            }
            else if (usingBook == true && Input.GetKeyDown(KeyCode.T))
            {
                uiBook.gameObject.SetActive(false);
                usingBook = false;
            }
        }

        //void AccessInventory()
        //{
            //if (invActive == false && Input.GetKeyDown(KeyCode.I))
            //{
                //invCanvas.SetActive(true);
            //    Inventory_Canvas.gameObject.SetActive(true);
            //    invActive = true;
            //}
            //else if (invActive == true && Input.GetKeyDown(KeyCode.I))
            //{
            //    //invCanvas.SetActive(false);
            //    Inventory_Canvas.gameObject.SetActive(false);
            //    invActive = false;
            //}
        //}
}
