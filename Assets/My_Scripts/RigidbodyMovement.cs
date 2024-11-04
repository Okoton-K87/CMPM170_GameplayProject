using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    // Input variables for player movement and mouse input
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot; // Used for camera rotation (pitch)

    // Serialized fields for setting in the Unity Inspector
    [SerializeField] private LayerMask FloorMask; // LayerMask to detect the floor for grounding
    [SerializeField] private Transform FeetTransform; // Player's feet position for ground detection
    [SerializeField] private Transform PlayerCamera; // Camera for first-person view
    [SerializeField] private Rigidbody PlayerBody; // Rigidbody for physics-based movement

    [Space]
    [SerializeField] private float Speed; // Movement speed
    [SerializeField] private float Sensitivity; // Mouse sensitivity for looking around
    [SerializeField] private float JumpForce; // Force applied for jumping

    private void Start()
    {
        // Lock the cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Capture player input for movement (WASD) and mouse look
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Call the methods responsible for moving the player and camera
        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        // Translate movement input into world space direction relative to where the player is facing
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;

        // Apply movement while preserving the player's current vertical velocity (for jumping)
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        // Jump if space is pressed and the player is grounded (using Physics.CheckSphere)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if the player's feet are grounded (using a small sphere at the feet)
            if (Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask))
            {
                // Apply an upward force to make the player jump
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }

    private void MovePlayerCamera()
    {
        // Adjust x-axis rotation for vertical camera movement (pitch)
        xRot -= PlayerMouseInput.y * Sensitivity;

        // Rotate the player object horizontally (yaw) based on mouse X input
        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);

        // Apply vertical camera rotation (pitch), clamping it to prevent extreme angles
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
