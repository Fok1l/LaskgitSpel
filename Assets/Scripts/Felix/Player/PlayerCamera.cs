using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    Camera mainCam;
    public Vector3 offset;
    public float damping;
    [SerializeField] private float maxXpos;
    [SerializeField] private float maxYpos;
    [SerializeField] private float minXpos;
    [SerializeField] private float minYpos;
    private Vector3 velocity = Vector3.zero; //Make variable velocity and initalizes it to 
    public CutsceneManager CutsceneManager;

    private void Start()
    {
       mainCam = GetComponent<Camera>();
       CutsceneManager = GameObject.FindObjectOfType<CutsceneManager>();
    }

    void FixedUpdate()
    {
        if (CutsceneManager.Overide == false)
        {
            Vector3 movePosition = target.position + offset; // Calculates the positon 
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping); //Updates it using a smooth damp. The Transform.positon sets the positon of the object and Vector3.SmoothDamp calculates the new positon. 
        }
        else 
        { 

        }
    }



}
