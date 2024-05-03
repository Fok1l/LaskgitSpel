using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class KeyScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D myBoxCollider;
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float deathCooldown;
    [SerializeField] float winCooldown;
    [SerializeField] float speed;

    Canvas winCanvas;
    SceneLoader sceneLoader;
    GameSession gameSession;

    public bool isAlive = true;
     
    public Canvas InvCanvas;
    public List<GameObject> blixtar;

    private float moveVertical;
    private float moveHorizontal;
    private int random;
    private bool hasCompletedLevel;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        if (isAlive == true)
        {
            MoveVertical();
            MoveHorizontal();
        }

        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Resistance"))) // To win and load next Scene
        {
            sceneLoader.LoadNextScene();
        }

        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Win")))
        {
            StartCoroutine(WinRoutine());
            FreezeMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D other) // To Die and reset Scene
    {
        if (other.tag == "Hazard" && !hasCompletedLevel)
        {
            isAlive = false;

            FreezeMovement();
            randomSpriteTrigger();
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator WinRoutine()
    {
        InvCanvas.enabled = true;
        gameSession.zapPuzzleKeyGained = true;
        hasCompletedLevel = true;

        StartCoroutine(sceneLoader.ZapPuzzleSpawn());
        yield return new WaitForSeconds(deathCooldown);
    }

    IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(deathCooldown);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // Reloading the scene
    }

    public void MoveVertical()
    {
        moveVertical = Input.GetAxis("Vertical");

        myRigidbody.velocity = new Vector2(moveVertical * speed, myRigidbody.velocity.y);
    }

    public void MoveHorizontal()
    {
        moveHorizontal = Input.GetAxis("Horizontal");

        myRigidbody.velocity = new Vector2(moveHorizontal * speed, myRigidbody.velocity.x);
    }

    public void FreezeMovement()
    {
        moveVertical = Input.GetAxis("Vertical");
        myRigidbody.velocity = new Vector2(0, 0); // To fix freeze movement when dead
    }

    void randomSpriteTrigger() // To spawn a random lightning when dying
    {
        random = Random.Range(0, blixtar.Count);
        blixtar[random].SetActive(true);
        blixtar[random].GetComponent<Transform>().position = transform.position + transform.up;
    }
}

