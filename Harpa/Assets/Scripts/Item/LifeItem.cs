using UnityEngine;

public class LifeItem : MonoBehaviour
{
    public float _healAmount = 20f;
    public PlayerLife playerLife;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("curado");
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerLife != null)
            {
                playerLife.Heal(_healAmount);
                gameObject.SetActive(false);
            }
        }
    }
}
