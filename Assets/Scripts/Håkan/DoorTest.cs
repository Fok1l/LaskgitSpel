using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    [SerializeField] Transform interactableReplacement;

    SidescrollerMovement player;
    BoxCollider2D boxCollider;
    EdgeCollider2D edgeCollider;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SidescrollerMovement>();
        boxCollider = GetComponent<BoxCollider2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HahaOpenSesame();

        
        
    }

    public void HahaOpenSesame()
    {
        if (player.iHaveKeycard == 1f)
        {
            boxCollider.enabled = false;
            interactableReplacement.transform.position = new Vector2(-21.92f, 2.39f);
            Destroy(gameObject);

        }
    }
}
