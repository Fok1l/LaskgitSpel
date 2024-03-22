using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class KeyScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D myBoxCollider;
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float deathCooldown;
    [SerializeField] float speed;

    SceneLoader sceneLoader;

    public bool isAlive = true;

    public List<GameObject> blixtar;

    private float moveVertical;
    private float moveHorizontal;
    private int random;
    private bool hasCompletedLevel;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Update()
    {
        if (isAlive == true)
        {
            MoveVertical();
            MoveHorizontal();
        }

        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Resistance"))) // To win and load next Scene
        {
            hasCompletedLevel = true;

            sceneLoader.LoadNextScene();
        }
    }

    private void OnTriggerExit2D(Collider2D other) // To Die and reset Scene
    {
        if (other.tag == "Hazard" && !hasCompletedLevel)
        {
            isAlive = false;

            DeathMovement();
            randomSpriteTrigger();
            StartCoroutine(DeathRoutine());
        }
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

    public void DeathMovement()
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

