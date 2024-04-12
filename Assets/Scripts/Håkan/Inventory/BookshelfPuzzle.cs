using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BookshelfPuzzle : MonoBehaviour
{
    [SerializeField] string bookshelfItem;
    [SerializeField] int numberOfItems;
    [SerializeField] GameObject exitDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.Find("ChildName");
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == bookshelfItem)
            {
                AddShelfItems();
                RemoveComponent();
            }
        }
    }

    void AddShelfItems()
    {
        numberOfItems++;
        if(numberOfItems == 10)
        {
            exitDoor.SetActive(false);
        }
    }

    void RemoveShelfItems()
    {
        numberOfItems--;
    }

    void RemoveComponent()
    {

    }


}
