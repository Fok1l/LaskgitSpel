using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSession : MonoBehaviour
{
    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<testSession>().Length;
        Debug.Log("gameSession found it self");

        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
