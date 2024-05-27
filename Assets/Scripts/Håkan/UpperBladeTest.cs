using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UpperBladeTest : MonoBehaviour
{
    [SerializeField] Vector2 screenPosition;
    [SerializeField] Vector2 worldPosition;
    [SerializeField] GameObject bladeSlot;
    [SerializeField] GameObject blade;
    public AudioClip pickupSound;
    public AudioClip placeSound;

    SaveTheBladeBool saveTheBladeBool;

    [Header("Slot position")]
    [SerializeField] Vector2 bladeSlotPosition;
    //[SerializeField]GameObject[] bladeSlotTags;
    [SerializeField] string slotName;


    PolygonCollider2D polygonCollider2D;
    SceneLoader loader;
    private AudioSource audioSource;


    private Vector3 originalPosition;
    private Vector3 originalScale;

    private bool ifollow;
    private bool playingSound = false;

    //public bool theBladeTestIsCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;


        polygonCollider2D = GetComponent<PolygonCollider2D>();
        loader = FindObjectOfType<SceneLoader>();
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
        audioSource = GetComponent<AudioSource>();

        new Vector2(-1.3f, 7.2f);

        ifollow = false;
        
    }

    void OnMouseDown()
    {
            ifollow = true;

    }
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (ifollow == true)
        {
            if (playingSound == false)
            {
                audioSource.PlayOneShot(pickupSound);
                playingSound = true;
            }
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.position = mousePos;
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (Input.GetMouseButtonUp(0))
            {
                audioSource.PlayOneShot(placeSound);
                playingSound = false;
                ifollow = false;
                transform.localScale = originalScale;
                transform.position = originalPosition;

                bladeSlot.GetComponent<Collider>();

                Collider2D[] colliders = Physics2D.OverlapPointAll(mouseWorldPos);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag(slotName) && blade.GetComponent<Collider2D>().enabled) //if mouse is inside the collider: && collider.bounds.Contains(mouseWorldPos) 
                    {
                        //snapp to the slot position
                        transform.position = bladeSlotPosition;
                        blade.GetComponent<Collider2D>().enabled = false;
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        loader.BladePuzzleComplete();
                        saveTheBladeBool.theBladeTestIsCompleted = true;



                        break;
                    }
                }
            }
        }
    }
}