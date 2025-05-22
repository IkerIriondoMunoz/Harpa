using UnityEngine;

public class LookAtShip : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = Vector3.zero;

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position + offset) - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation = lookRotation;
        }
    }
}
