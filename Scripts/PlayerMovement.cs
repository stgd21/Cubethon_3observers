
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Physics Component of player cube
    public Rigidbody rb;
    //Forces to set in inspector
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float maxVelocity = 200f;

    // FixedUpdate is called evenly across framerates
    void FixedUpdate()
    {
        //Add force to propel player forward
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity *= maxVelocity;
        }

        if (Input.GetKey("d"))
        {
            //Move the player right when D key is pushed
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,
                ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            //Move the player left when A key is pushed
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,
                ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            //End the game if the player goes off the edge
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}