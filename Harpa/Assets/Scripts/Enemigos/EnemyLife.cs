using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public float _maxLife = 100f;
    public float _currentLife = 100f;
    public float _damageRecived = 10f;

    void Start()
    {
        _currentLife = _maxLife;
    }

    void Update()
    {
        if (_currentLife <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Damage(_damageRecived);
       }
    }

    public void Damage(float damageRecived)
    {
        _currentLife -= damageRecived;
    }
}
