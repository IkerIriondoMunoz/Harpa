using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public Canvas _controlsCanvas;
    public Canvas _canvasMenu;
    public int _nextScene;

    public void Jugar()
    {
        SceneManager.LoadScene(_nextScene);
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
