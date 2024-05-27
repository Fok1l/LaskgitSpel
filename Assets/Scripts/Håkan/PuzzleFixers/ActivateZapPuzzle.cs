using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZapPuzzle : MonoBehaviour
{
    [SerializeField] GameObject zapPuzzleLights1;
    [SerializeField] GameObject zapPuzzleLights2;

    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSession.wirePuzzleComplete == true)
        {
            zapPuzzleLights1.SetActive(true);
            zapPuzzleLights2.SetActive(true);
            Destroy(this);
        }
    }
}
