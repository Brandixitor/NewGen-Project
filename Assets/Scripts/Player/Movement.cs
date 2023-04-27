using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;  // The speed of movement
    public float jumpForce = 5f;  // The force of jumping
    public float gravity = 20f;  // The force of gravity
    private CharacterController controller;  // The CharacterController component
    private Vector3 moveDirection;  // The movement direction

    private void Start()
    {
        controller = GetComponent<CharacterController>();  // Get the CharacterController component
    }

    private void Update()
    {
        // Get the horizontal and vertical inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontal, 0f, vertical);
        movementDirection = transform.TransformDirection(movementDirection);
        movementDirection *= moveSpeed;

        // Apply the movement direction to the CharacterController component
        controller.Move(movementDirection * Time.deltaTime);

        // Apply gravity to the movement direction
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        // Check if the player is jumping
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            // Apply a force in the upward direction to simulate jumping
            moveDirection.y = jumpForce;
        }
    }
}
