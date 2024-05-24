using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeUsageFixer : MonoBehaviour
{

    [SerializeField] BoxCollider2D bladeCollider;
    [SerializeField] BoxCollider2D zapCollider;

    SaveTheBladeBool saveTheBladeBool;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (saveTheBladeBool.theBladeTestIsCompleted)
        {
            bladeCollider.enabled = false;
        }
        if (gameSession.zapPuzzleKeyGained == true)
        {
            zapCollider.enabled = false;
        }
    }
}
