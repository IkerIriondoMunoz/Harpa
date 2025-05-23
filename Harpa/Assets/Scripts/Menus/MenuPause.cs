using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Canvas _canvasMenu;
    private bool _menuOpen;
    public Canvas _controlsCanvas;
    public Canvas _settingsCanvas;

    public SC_ThirdPersonMovement player;

    public int _nextScene;

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
                player.cursorLockUnlock(true);
            }
            else
            {
                player.cursorLockUnlock(false);
                _canvasMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                _menuOpen = true;
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_nextScene);
        Time.timeScale = 1f;
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
