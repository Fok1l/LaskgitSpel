using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBladePuzzle : MonoBehaviour
{

    SceneLoader loader;
    [SerializeField] int teleportTo;
    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            loader.Teleporters(teleportTo);
        }
    }
}
