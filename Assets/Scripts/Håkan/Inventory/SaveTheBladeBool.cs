using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheBladeBool : MonoBehaviour
{
    public static SaveTheBladeBool Instance;
    
    public bool theBladeTestIsCompleted = false;
    public bool tutorialText = false;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
