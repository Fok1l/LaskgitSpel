using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float damping;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero; //Make variable velocity and initalizes it to 0

    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset; // Calculates the positon 
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping); //Smooths the camera.
    }
}
