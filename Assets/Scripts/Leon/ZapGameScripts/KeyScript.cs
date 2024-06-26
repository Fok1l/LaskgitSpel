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
    PlayerSpawner playerSpawner;

    public bool isAlive = true;
     
    public Canvas InvCanvas;
    public List<GameObject> blixtar;
    public GameObject blixtAnim;
    public AudioClip blixtSound;
    public AudioSource audioSource;

    private float moveVertical;
    private float moveHorizontal;
    private int random;
    private bool hasCompletedLevel;

    private void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
       // blixtAnim.SetActive(true);
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
        playerSpawner.spawnAtZapPuzzle = true;
        hasCompletedLevel = true;

        playerSpawner.playerSpawnPosition = new Vector3(16.90145f, 2.37239f, 0f);
        StartCoroutine(sceneLoader.ZapPuzzleSpawn());
        yield return new WaitForSeconds(deathCooldown);
    }

    IEnumerator DeathRoutine()
    {
        if (blixtSound != null)
        {
            audioSource.clip = blixtSound;
            audioSource.Play();
        }
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
       // random = Random.Range(0, blixtar.Count);
       // blixtar[random].SetActive(true);
       // blixtar[random].GetComponent<Transform>().position = transform.position + transform.up;
        //blixtAnim.SetActive(false);

        blixtAnim.SetActive(true);
    }
}

