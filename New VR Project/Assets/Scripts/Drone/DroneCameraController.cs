using UnityEngine;

public class DroneCameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float boostMultiplier = 3f;
    public float lookSensitivity = 2f;

    private float rotationX = 90f;
    private float rotationY = 0f;

    void Start()
    {
        // Lock cursor for better mouse control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= boostMultiplier;
        }

        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) move += transform.forward;
        if (Input.GetKey(KeyCode.S)) move -= transform.forward;
        if (Input.GetKey(KeyCode.A)) move -= transform.right;
        if (Input.GetKey(KeyCode.D)) move += transform.right;
        if (Input.GetKey(KeyCode.Space)) move += transform.up;
        if (Input.GetKey(KeyCode.C)) move -= transform.up;

        transform.position += move * speed * Time.deltaTime;
    }

    void HandleRotation()
    {
        rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);  // Avoid flipping upside down

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
