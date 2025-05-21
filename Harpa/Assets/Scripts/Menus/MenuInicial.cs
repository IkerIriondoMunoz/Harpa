using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public Canvas _controlsCanvas;
    public Canvas _canvasMenu;

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void Controles()
    {
        _canvasMenu.gameObject.SetActive(false);
        _controlsCanvas.gameObject.SetActive(true);
    }

    public void SalirControles()
    {
        _canvasMenu.gameObject.SetActive(true);
        _controlsCanvas.gameObject.SetActive(false);
    }
}
