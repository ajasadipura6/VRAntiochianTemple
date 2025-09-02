using UnityEngine;
using UnityEngine.InputSystem; // For new Input System

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float sprintSpeed = 6.0f;
    public float jumpHeight = 2.0f;
    public float gravity = 9.8f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to stick to the ground
        }

        // Get movement input
        float moveX = (Keyboard.current.aKey.isPressed ? -1 : Keyboard.current.dKey.isPressed ? 1 : 0);
        float moveZ = (Keyboard.current.sKey.isPressed ? -1 : Keyboard.current.wKey.isPressed ? 1 : 0);

        // Determine movement speed (sprint if Shift is held)
        float speed = Keyboard.current.leftShiftKey.isPressed ? sprintSpeed : walkSpeed;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Jumping logic
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
