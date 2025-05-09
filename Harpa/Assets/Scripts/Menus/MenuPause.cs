using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Canvas _canvasMenu;
    private bool _menuOpen;
    public Canvas _controlsCanvas;
    public Canvas _settingsCanvas;

    void Start()
    {
        _canvasMenu.gameObject.SetActive(false);
        _controlsCanvas.gameObject.SetActive(false);
        _settingsCanvas.gameObject.SetActive(false);
        _menuOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_menuOpen)
            {
                _canvasMenu.gameObject.SetActive(false);
                _controlsCanvas.gameObject.SetActive(false);
                _settingsCanvas.gameObject.SetActive(false);
                Time.timeScale = 1f;
                _menuOpen = false;
            }
            else
            {
                _canvasMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                _menuOpen = true;
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
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

    public void Settings()
    {
        _canvasMenu.gameObject.SetActive(false);
        _settingsCanvas.gameObject.SetActive(true);
    }
}
