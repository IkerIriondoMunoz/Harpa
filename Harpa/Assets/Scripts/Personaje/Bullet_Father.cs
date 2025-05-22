using UnityEngine;

public class Bullet_Father : MonoBehaviour
{
    private float lifespan = 0.75f;
    private bool collided;

    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}