using UnityEngine;

public class Cristal : MonoBehaviour
{
    public GameObject efectoExplosion;
    public float retardoExplosion = 1.5f;

    private bool activada = false;
    private Transform objetivo;
    public PlayerLife playerLife;

    public float _damage = 40f;
    private bool _onTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (!activada && other.CompareTag("Player"))
        {
            activada = true;
            objetivo = other.transform;
            Debug.Log("Jugador detectado. Cuenta atrás iniciada.");
            Invoke(nameof(Detonar), retardoExplosion);
            _onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onTrigger = false;
        }
    }

    private void Detonar()
    {
        if (efectoExplosion != null)
        {
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);
        }

        if (_onTrigger)
        {
            playerLife.Damage(_damage);
        }
        
        Destroy(gameObject);
    }
}
