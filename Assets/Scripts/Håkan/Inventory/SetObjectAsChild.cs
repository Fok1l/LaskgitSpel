using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectAsChild : MonoBehaviour
{

    [SerializeField] GameObject childObject;
    GameSession gameSession;
    Bookshelf bookshelf;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        bookshelf = FindObjectOfType<Bookshelf>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Y))
        //{
        //    transform.SetParent(parentTransform);
        //}
        CreateJarItem();
        
    }

    void CreateJarItem()
    {
        if (gameSession.spawnTheBookPuzzleJar == true && bookshelf.SpawnAJar == true)
        {
            Instantiate(childObject, transform );
        }     
    }
}
