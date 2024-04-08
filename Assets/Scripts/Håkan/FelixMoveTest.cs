using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelixMoveTest : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;


    bool invActive = false;
    
    public Canvas Inventory_Canvas;

    [Header("Items N Flashlight")]
    [SerializeField] GameObject tidning;
    [SerializeField] GameObject unlitFlashLight;
    [SerializeField] GameObject litFlashLight;
    [SerializeField] GameObject flashLightObject;
    
    GameSession gameSession;
    public bool usingFlashLight = false;

    [Header("Quest Book")]
    [SerializeField] GameObject uiBook;
    public bool usingBook = false;
    [SerializeField] GameObject openBook;
    [SerializeField] GameObject closeBook;

    [Header("Quests")]
    [SerializeField] GameObject testQuest;
    //bool testQuestDone = false;
    public bool lightGained = false;

    private void Start()
    {
        //invCanvas = FindObjectOfType<GameObject>();
        invActive = false;
        gameSession = FindObjectOfType<GameSession>();
        //invCanvas.SetActive(false);
    }

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the input vector to ensure consistent speed
        moveInput.Normalize();

        // Snap the input to the closest cardinal direction
        moveInput = SnapToYX(moveInput);

        rb2d.velocity = moveInput * moveSpeed;


        AccessInventory();
        

    }

    //This is to snap the movement to only left, right, up, and down. 
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

    void AccessInventory()
    {
        if (invActive == false && Input.GetKeyDown(KeyCode.I))
        {
            //invCanvas.SetActive(true);
            Inventory_Canvas.gameObject.SetActive(true);
            invActive = true;
            if (gameSession.tidningGained == true)
            {
                tidning.gameObject.SetActive(true);
                testQuest.gameObject.SetActive(true);
            }
        } else if (invActive == true && Input.GetKeyDown(KeyCode.I))
        {
            //invCanvas.SetActive(false);
            Inventory_Canvas.gameObject.SetActive(false);
            invActive = false;
        }

        if (!usingFlashLight && Input.GetKeyDown(KeyCode.F))
        {
            //unlitFlashLight.gameObject.SetActive(false);
            usingFlashLight = true;
            //litFlashLight.gameObject.SetActive(true);
            flashLightObject.SetActive(true);
        }else if (usingFlashLight == true && Input.GetKeyDown(KeyCode.F))
        {
            //unlitFlashLight.gameObject.SetActive(true);
            usingFlashLight = false;
            //litFlashLight.gameObject.SetActive(false);
            flashLightObject.SetActive(false);
        }

        if (!usingBook && Input.GetKeyDown(KeyCode.M))
        {
            uiBook.gameObject.SetActive(true);
            usingBook = true;
            closeBook.gameObject.SetActive(false);
            openBook.gameObject.SetActive(true);
        }
        else if(usingBook == true && Input.GetKeyDown(KeyCode.M))
        {
            uiBook.gameObject.SetActive(false);
            usingBook = false;
            openBook.gameObject.SetActive(false);
            closeBook.gameObject.SetActive(true);
        }



        


        if(lightGained == true)
        {
            //testQuestDone = true;
            Destroy(testQuest.gameObject);
        }
    }
}