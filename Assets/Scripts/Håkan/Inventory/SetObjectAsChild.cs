using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectAsChild : MonoBehaviour
{

    [SerializeField] GameObject childObject;
    UpperBladeTest upperBladeTest;
    // Start is called before the first frame update
    void Start()
    {
        upperBladeTest = FindObjectOfType<UpperBladeTest>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Y))
        //{
        //    transform.SetParent(parentTransform);
        //}
        CreateJarItem();
        
    }

    void CreateJarItem()
    {
        //if (//!upperBladeTest.theBladeTestIsCompleted)
        {
            Instantiate(childObject, transform );

        }
        
        
    }
}
