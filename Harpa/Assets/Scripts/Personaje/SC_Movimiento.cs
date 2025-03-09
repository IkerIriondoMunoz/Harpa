using UnityEngine;

public class SC_Movimiento : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float runSpeed = 12f;
    private float currentSpeed;

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = -9.81f;

    public CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        Movement();
        ApplyGravity();
    }

    private void Movement()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        characterController.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
