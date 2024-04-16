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
    void FixedUpdate()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == bookshelfItem && !gameObject.activeInHierarchy)
            {

            } else
            {
                AddShelfItem();
                RemoveComponent(eachChild);
            }
        }
    }

    void AddShelfItem()
    {
        gameObject.SetActive(true);
        numberOfItems++;
        if (numberOfItems == 10)
        {
            exitDoor.SetActive(false);
        }
    }

    void RemoveShelfItem()
    {
        numberOfItems--;
    }

    void RemoveComponent(Transform child)
    {
        Destroy(child.gameObject);
    }

}