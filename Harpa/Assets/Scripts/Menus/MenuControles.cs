using UnityEngine;
using UnityEngine.UI;

public class MenuControles : MonoBehaviour
{
    public Canvas _canvasMenu;
    public Canvas _controlsCanvas;

   public void CloseControls()
    {
        _canvasMenu.gameObject.SetActive(true);
        _controlsCanvas.gameObject.SetActive(false);
    }
}
