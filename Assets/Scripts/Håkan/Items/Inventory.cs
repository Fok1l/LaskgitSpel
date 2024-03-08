using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] int dynamite = 0;
    [SerializeField] int keycard = 0;
    [SerializeField] int yourMom = 0;
    [SerializeField] int momJokesForDummies = 0;
    [SerializeField] int howToMakeAGoodShooter = 0;
    [SerializeField] int overwatchFormula = 0;
    [SerializeField] bool key = false;
    // Start is called before the first frame update

    private void Awake()
    {
        int numberOfInventories = FindObjectsOfType<Inventory>().Length;

        if (numberOfInventories > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DynamiteGain();
        KeyUsage();
    }

    public void DynamiteGain()
    {
        dynamite++;

        Destroy(gameObject);
    }

    public void KeyUsage()
    {

    }
}
