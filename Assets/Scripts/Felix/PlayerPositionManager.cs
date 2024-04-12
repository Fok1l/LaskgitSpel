using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    private Vector3 storedPosition;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StorePosition(Vector3 position)
    {
        storedPosition = position;
    }

    public Vector3 RetrievePosition()
    {
        return storedPosition;
    }
}

