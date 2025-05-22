using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPersonajes : MonoBehaviour
{
    public Canvas _mainMenu;
    public Canvas _sSetting;
    public Canvas _nSetting;
    public int _nextSceneN;
    public int _nextSceneS;
    public int _nextScene;

    private void Start()
    {
        _mainMenu.gameObject.SetActive(true);
        _sSetting.gameObject.SetActive(false);
        _nSetting.gameObject.SetActive(false);
    }

    public void Supernova()
    {
        SceneManager.LoadScene(_nextSceneS);
    }
    public void Nebulosa()
    {
        SceneManager.LoadScene(_nextSceneN);
    }

    public void SSetting()
    {
        _mainMenu.gameObject.SetActive(false);
        _sSetting.gameObject.SetActive(true);
    }

    public void NSetting()
    {
        _mainMenu.gameObject.SetActive(false);
        _nSetting.gameObject.SetActive(true);
    }

    public void BackSSetting()
    {
        _mainMenu.gameObject.SetActive(true);
        _sSetting.gameObject.SetActive(false);
    }

    public void BackNSetting()
    {
        _mainMenu.gameObject.SetActive(true);
        _nSetting.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
