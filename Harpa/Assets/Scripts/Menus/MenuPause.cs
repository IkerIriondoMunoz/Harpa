using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Canvas _canvasMenu;
    public GameObject _player;
    private bool _menuOpen;

    void Start()
    {
        _canvasMenu.gameObject.SetActive(false);
        _menuOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && _menuOpen == false)
        {
            _canvasMenu.gameObject.SetActive(true);
            _player.SetActive(false);
            _menuOpen = true;
        }

        if (Input.GetKeyUp(KeyCode.Q) && _menuOpen == true)
        {
            _canvasMenu.gameObject.SetActive(false);
            _player.SetActive(true);
            _menuOpen = false;
        }
    }
}
