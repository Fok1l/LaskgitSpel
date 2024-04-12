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
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == bookshelfItem)
            {
                AddShelfItems();
                AddShelfItem();
                RemoveComponent(eachChild);
            }
        }
    }

    void AddShelfItem()
    {
        numberOfItems++;
        if (numberOfItems == 10)
        {
            exitDoor.SetActive(false);
        }
        if (numberOfItems == numberOfItems++)
        {
            RemoveComponent();
        }
    }

    void RemoveShelfItem()
    {
        numberOfItems--;
    }

    void RemoveComponent(Transform child)
    {
        //Destroy(this);
        Destroy(child.gameObject);
    }
}