using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SaveTheBladeBool saveTheBladeBool;

    [Header("spawn positions")]
    public Vector2 playerSpawnPosition;

    public bool dontActivateSpawnTimer;
    public bool dontSpawnBladePuzzle;
    public bool spawnBladePuzzle;
    public bool spawnAtZapPuzzle = false;
    // Start is called before the first frame update
    void Start()
    {
        saveTheBladeBool = FindObjectOfType<SaveTheBladeBool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //W.I.P Håkan
    void FirstSpawn()
    {
        if (saveTheBladeBool.stopFirstTimeSpawn == false)
        {
            playerSpawnPosition = new Vector2(7.902787f, -8.278445f);
            saveTheBladeBool.stopFirstTimeSpawn = true;
        }
    }

    //            else if (currentSceneIndex == 3 && playerSpawner.spawnAtZapPuzzle == true && saveTheBladeBool.theBladeTestIsCompleted == true)
    //        {
    //            dontActivateTimer = true;
    //            
            //}
}
