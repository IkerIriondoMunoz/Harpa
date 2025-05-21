using UnityEngine;
using UnityEngine.Apple;

public class PlayerShoot : MonoBehaviour
{

    public Camera Camera;

    public GameObject projectile;
    public Transform firePoint;

    public SC_ThirdPersonMovement Player;

    public float projectileSpeed = 30f;
    private float timeToFire;
    public float fireRate = 4f;

    private Vector3 destination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= timeToFire && Player.cameraLock == true)
        {
            timeToFire = Time.time +1/fireRate;
            shootProjectile();
        }
    }

    void shootProjectile()
    {
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        spawnProjectile(firePoint);
    }

    void spawnProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile,firePoint.position,Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
