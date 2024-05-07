using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectAsChild : MonoBehaviour
{

    [SerializeField] GameObject childObject;
    GameSession gameSession;
    SaveTheBladeBool saveTheBladeBool;
    Bookshelf bookshelf;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
        bookshelf = FindObjectOfType<Bookshelf>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateJarItem();
    }

    void CreateJarItem()
    {
        if (saveTheBladeBool.theBladeTestIsCompleted == true && bookshelf.spawnAJar == true)
        {
            Debug.Log("hello");
            Instantiate(childObject, transform );
            Destroy(this);
        }     
    }
}
