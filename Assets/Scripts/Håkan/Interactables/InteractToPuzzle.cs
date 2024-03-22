using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToPuzzle : MonoBehaviour
{
    SceneLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            loader.LoadBladeScene();
        }
    }
}
