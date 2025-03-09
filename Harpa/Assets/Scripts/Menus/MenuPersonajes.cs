using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPersonajes : MonoBehaviour
{
    public void Supernova()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Nebulosa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
