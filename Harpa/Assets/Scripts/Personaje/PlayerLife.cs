using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Image _lifeBar;
    public float _maxLife = 100f;
    public float _currentLife = 100f;

    void Start()
    {
        _currentLife = _maxLife;
    }

    void Update()
    {
        _lifeBar.fillAmount = _currentLife / _maxLife;

        if(_currentLife <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Damage(float damageRecived)
    {
        _currentLife -= damageRecived;
    }

    public void Heal(float healAmount)
    {
        _currentLife += healAmount;

        if (_currentLife > _maxLife)
        {
            _currentLife = _maxLife;
        }
    }
}
