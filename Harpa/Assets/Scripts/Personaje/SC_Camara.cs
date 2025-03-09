using UnityEngine;

public class SC_Camara : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float rotationSpeed = 3f;

    private float currentX = 0f;
    private float currentY = 0f;
    public float minY = -20f, maxY = 60f;

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, minY, maxY);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
