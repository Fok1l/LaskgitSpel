using UnityEngine;

public class BookshelfPuzzle : MonoBehaviour
{
    [SerializeField] string bookshelfItem;
    [SerializeField] int numberOfItems;
    int trueNumberOfItems = 1;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
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
        if (numberOfItems == 1)
        {
            sceneLoader.LoadEndingScene();
        }
        if (numberOfItems > 1)
        {
            numberOfItems--;
        }
    }

    void RemoveShelfItem()
    {
        numberOfItems--;
    }

    void RemoveComponent(Transform child)
    {
        //Destroy(child.gameObject);
    }
}