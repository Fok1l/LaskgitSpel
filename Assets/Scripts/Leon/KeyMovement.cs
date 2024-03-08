using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;

    public float speed;

    private float moveVertical;
    private float moveHorizontal;

    void Update()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    public void MoveVertical()
    {
        moveVertical = Input.GetAxis("Vertical");

        myRigidbody.velocity = new Vector2(moveVertical * speed, myRigidbody.velocity.y);
    }

    public void MoveHorizontal()
    {
        moveHorizontal = Input.GetAxis("Horizontal");

        myRigidbody.velocity = new Vector2(moveHorizontal * speed, myRigidbody.velocity.x);
    }

    public void DeathMovement()
    {
        moveVertical = Input.GetAxis("Vertical");
        myRigidbody.velocity = new Vector2(0, 0); // To fix freeze movement when dead
    }
}
