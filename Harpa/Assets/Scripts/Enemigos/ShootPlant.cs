using UnityEngine;

public class ShootPlant : MonoBehaviour
{
    public Transform player;             
    public GameObject projectilePrefab;  
    public Transform shootPoint;         
    public float detectionRange = 15f;
    public float fireRate = 1f;

    private bool isPlayerInRange = false;
    private float fireTimer = 0f;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isPlayerInRange = true;
            RotateTowardsPlayer();

            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate)
            {
                Fire();
                fireTimer = 0f;
            }
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Fire()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
