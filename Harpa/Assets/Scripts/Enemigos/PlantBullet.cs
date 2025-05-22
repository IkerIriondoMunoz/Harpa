using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public float damage;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLife player = other.GetComponent<PlayerLife>();
        if (player != null)
        {
            player.Damage(damage);
            Destroy(gameObject);
        }
    }
}
