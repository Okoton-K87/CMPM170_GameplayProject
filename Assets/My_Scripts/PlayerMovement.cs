using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Speed of movement
    public float jumpForce = 7f;      // Jump force
    private Rigidbody rb;             // Reference to Rigidbody component
    private bool isGrounded = true;   // Check if the player is grounded

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement input using the default Unity Input Manager (WASD)
        float moveHorizontal = Input.GetAxis("Horizontal");  // A/D or Left/Right Arrows
        float moveVertical = Input.GetAxis("Vertical");      // W/S or Up/Down Arrows

        // Calculate the direction relative to where the player is facing (world space movement)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Apply movement based on Rigidbody's velocity
        Vector3 moveVelocity = movement * moveSpeed;
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // Prevent jumping until grounded again
        }
    }

    // Detect if player is grounded by checking collision with the ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Allow jumping again
        }
    }
}
