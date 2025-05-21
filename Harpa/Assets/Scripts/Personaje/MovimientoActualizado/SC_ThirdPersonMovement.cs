using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class SC_ThirdPersonMovement : MonoBehaviour
{
    public CharacterController cc;
    public Transform cameraPosition;
    public Animator animator;
    public CinemachineCamera cameraPlayer;


    public float speed = 4f;
    private Vector3 direccion;

    private float verticalVelocity = -9.81f;


    private bool cameraLock = false;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // Update is called once per frame

    private void Start()
    {
        cursorLockUnlock(true);
    }
    void Update()
    {
        cc.Move(new Vector3(0,verticalVelocity,0));
        if (IsMovementActive())
        {
            MovementManager();
            CameraLockManager();
        }

        if (cameraLock == false)
        {
            // Modo "Freelook": Siempre reproduce la animación de caminar hacia adelante
            float moveMagnitude = direccion.magnitude;
            animator.SetFloat("ZSpeed", moveMagnitude > 0.1f ? 1f : 0f); // Fija ZSpeed a 1 si hay movimiento
            animator.SetFloat("XSpeed", 0f); // XSpeed siempre es 0
        }
        else
        {
            // Modo "Camera Lock": Usa la dirección local para las animaciones
            Vector3 localDirection = transform.InverseTransformDirection(direccion);
            animator.SetFloat("ZSpeed", localDirection.z);
            animator.SetFloat("XSpeed", localDirection.x);
        }


        if (Input.GetKeyDown(KeyCode.Mouse1) && cameraLock == false)
        {
            cameraLock = true;
            animator.SetBool("isAiming",true);
            cameraPlayer.Lens.FieldOfView = 20f;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && cameraLock == true)
        {
            cameraLock = false;
            animator.SetBool("isAiming", false);
            cameraPlayer.Lens.FieldOfView = 60f;
        }
    }

    void CameraLockManager()
    {
        if (cameraLock == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direccion = transform.forward * vertical + transform.right * horizontal;

            transform.rotation = Quaternion.Euler(0f,cameraPosition.eulerAngles.y,0f);

            cc.Move(direccion * speed * Time.deltaTime);
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

                float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cameraPosition.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                cc.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
        }
    }
    bool IsMovementActive()
    {
        return !GameObject.FindWithTag("Task");
    }

    public void cursorLockUnlock(bool locked)
    {
        if (locked == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
