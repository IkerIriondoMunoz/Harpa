using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyDamage : MonoBehaviour
{
    public float _damage = 20f;
    public PlayerLife playerLife;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dañado");
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerLife != null)
            {
                playerLife.Damage(_damage);
            }
        }
    }
}
