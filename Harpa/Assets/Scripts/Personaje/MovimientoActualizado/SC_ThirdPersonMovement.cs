using Unity.Mathematics;
using UnityEngine;

public class SC_ThirdPersonMovement : MonoBehaviour
{
    public CharacterController cc;
    public Transform Camara;


    public float speed = 6f;

    private bool cameraLock = false;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // Update is called once per frame
    void Update()
    {
        MovementManager();
        CameraLockManager();

        if (Input.GetKeyDown(KeyCode.Q) && cameraLock == false)
        {
            cameraLock = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && cameraLock == true)
        {
            cameraLock = false;
        }
        Debug.Log(cameraLock);
    }

    void CameraLockManager()
    {
        if (cameraLock == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direccion = transform.forward * vertical + transform.right * horizontal;

            transform.rotation = Quaternion.Euler(0f,Camara.eulerAngles.y,0f);
            
            cc.Move(direccion * speed * Time.deltaTime);
        }
    }
    void MovementManager()
    {
        if (cameraLock == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

            if (direccion.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + Camara.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                cc.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
        }
    }
}
