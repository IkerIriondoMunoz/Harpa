using Unity.Mathematics;
using UnityEngine;

public class SC_ThirdPersonMovement : MonoBehaviour
{
    public CharacterController cc;
    public Transform Camara;
    public Animator animator;


    public float speed = 6f;
    private Vector3 direccion;

    float gravityValue = 9.8f;
    private float groundedTimer = 0f;

    private float verticalVelocity = 9.8f;


    private bool cameraLock = false;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // Update is called once per frame

    void Update()
    {
        if (IsMovementActive())
        {
            MovementManager();
            CameraLockManager();
        }

        if (cameraLock == false)
        {
            // Modo "Freelook": Siempre reproduce la animaci�n de caminar hacia adelante
            float moveMagnitude = direccion.magnitude;
            animator.SetFloat("ZSpeed", moveMagnitude > 0.1f ? 1f : 0f); // Fija ZSpeed a 1 si hay movimiento
            animator.SetFloat("XSpeed", 0f); // XSpeed siempre es 0
        }
        else
        {
            // Modo "Camera Lock": Usa la direcci�n local para las animaciones
            Vector3 localDirection = transform.InverseTransformDirection(direccion);
            animator.SetFloat("ZSpeed", localDirection.z);
            animator.SetFloat("XSpeed", localDirection.x);
        }


        if (Input.GetKeyDown(KeyCode.R) && cameraLock == false)
        {
            cameraLock = true;
        }
        else if (Input.GetKeyDown(KeyCode.R) && cameraLock == true)
        {
            cameraLock = false;
        }
    }

    void CameraLockManager()
    {
        if (cameraLock == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direccion = transform.forward * vertical + transform.right * horizontal;

            transform.rotation = Quaternion.Euler(0f,Camara.eulerAngles.y,0f);

            cc.Move(direccion * speed * Time.deltaTime);
        }
        if (cc.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = 0; // Si el player toca suelo, eliminamos la velocidad vertical
        }
    }
    void MovementManager()
    {
        if (cameraLock == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direccion = new Vector3(horizontal, 0f, vertical).normalized;

            if (direccion.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + Camara.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                cc.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
        }
        if (cc.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = 0; // Si el player toca suelo, eliminamos la velocidad vertical
        }
    }
    bool IsMovementActive()
    {
        return !GameObject.FindWithTag("Task");
    }
}
