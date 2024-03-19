using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class MouseClick : MonoBehaviour
{
    [SerializeField] int dynamiteAmount = 0;

    [SerializeField] LayerMask dynamite;
    // Start is called before the first frame updates
    Inventory inventory;
    void Start()
    {
        inventory = GetComponent<Inventory>();
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
                dynamiteAmount++;

                //Check if it works and how many
                Debug.Log("Dynamite Amount: " + dynamiteAmount);

                //inventory.DynamiteGain();
                if (dynamiteAmount == 1)
                {
                    dynamiteAmount--;
                    //Destroy(gameObject);
                    //Destroy(rayhit.collider.gameObject);
                    if (dynamiteAmount == 0)
                    {
                        Destroy(rayhit.collider.gameObject);
                    }
                }
                
            }
        }
    }

    public int GetDynamiteAmount()
    {
        return dynamiteAmount;
    }

    public void DecreaseDynamiteAmount(int amount)
    {
        dynamiteAmount -= amount;
    }
}
