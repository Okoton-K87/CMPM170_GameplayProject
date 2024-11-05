using System.Collections;
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
    [SerializeField] private float GravityIntensity = 9.81f; // Custom gravity intensity

    private bool isGrounded;
    private float originalSpeed; // Store the original speed

    private void Start()
    {
        // Lock the cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Initialize the original speed
        originalSpeed = Speed;
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

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask);

        // Jump if space is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply an upward force to make the player jump
            PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        // Apply custom gravity if the player is not grounded
        if (!isGrounded)
        {
            PlayerBody.AddForce(Vector3.down * GravityIntensity, ForceMode.Acceleration);
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

    // Coroutine for Speed Boost
    public IEnumerator SpeedBoost(float amount, float duration)
    {
        Speed += amount; // Increase speed by the specified amount
        yield return new WaitForSeconds(duration); // Wait for the boost duration
        Speed = originalSpeed; // Revert to the original speed
        Debug.Log("Speed boost ended. Player's speed reverted to " + originalSpeed);
    }
}
