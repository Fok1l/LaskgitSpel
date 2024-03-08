using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladePuzzle : MonoBehaviour
{

    [SerializeField] LayerMask blade;
    // Start is called before the first frame update

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("hola");
            //cast a ray from the mouse to the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            Debug.Log("oh mah gawd");

            //check if the raycast hits a object with "Dynamite" tag
            var rayhit = Physics2D.Raycast(ray.origin, ray.direction);
            if (rayhit.collider != null)
            {
                Debug.Log("Why wont it work");
                rayhit.collider.gameObject.transform.localScale = new Vector2(0.75f, 0.75f);
                rayhit.collider.gameObject.transform.position = Input.mousePosition;

                //Check if it works and how many
                Debug.Log("Dynamite Amount: ");

                //Destroy(rayhit.collider.gameObject);
            }
        }
    }
}
