using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            sceneLoader.LoadNextScene();
        }
    }
}
