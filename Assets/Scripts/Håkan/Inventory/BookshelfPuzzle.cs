using UnityEngine;

public class BookshelfPuzzle : MonoBehaviour
{
    [SerializeField] string bookshelfItem;
    [SerializeField] int numberOfItems;
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

    void AddShelfItem() // Makes sure that no more than 1 jar will spawn and that you win
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

    void RemoveComponent(Transform child)
    {
        //Destroy(child.gameObject);
    }
}