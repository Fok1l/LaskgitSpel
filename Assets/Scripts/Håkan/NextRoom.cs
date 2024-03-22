using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    [SerializeField] int teleportTo;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        loader.Teleporters(teleportTo);
    }
}
