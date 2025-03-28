using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    public Canvas canvasText;
    public Canvas canvasInput;
    public Text _text;
    public string _message;
    public GameObject _player;

    void Start()
    {
        canvasText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider _collider)
    {  
        canvasInput.gameObject.SetActive(true);
       if (Input.GetKeyDown(KeyCode.E))
        {
            canvasInput.gameObject.SetActive(false);
            canvasText.gameObject.SetActive(true);
            _player.SetActive(false);
            _text.text = _message;
        }
       if (Input.GetKeyDown(KeyCode.E))
        {
            _player.SetActive(false);
            canvasInput.gameObject.SetActive(true);
            canvasText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        canvasText.gameObject.SetActive(false);
    }

}
