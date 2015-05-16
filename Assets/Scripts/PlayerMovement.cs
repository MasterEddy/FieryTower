using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f;
    public float jumpSpeed = 6f;
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    bool onGround = false;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Move the player around the scene.
        Move(h, v);
	}

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (onGround)
        {
            playerRigidbody.velocity += jumpSpeed * Vector3.up;
            onGround = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            onGround = true;
        }
    }
}
