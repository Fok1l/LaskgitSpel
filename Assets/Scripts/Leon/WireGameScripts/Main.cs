using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public int SwitchCount;
    public GameObject winText;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchChange(int points) { 
    onCount = onCount + points;
        if (onCount == SwitchCount)
        {
            winText.SetActive(true);
        }
    
    
    
    
    }
}
