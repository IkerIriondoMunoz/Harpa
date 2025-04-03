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
    private bool isPlayerInTrigger = false;

    void Start()
    {
        canvasText.gameObject.SetActive(false);
        canvasInput.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            canvasInput.gameObject.SetActive(true);
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            canvasText.gameObject.SetActive(false);
            canvasInput.gameObject.SetActive(false);
            isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            bool isTextActive = canvasText.gameObject.activeSelf;
            canvasText.gameObject.SetActive(!isTextActive);
            canvasInput.gameObject.SetActive(isTextActive);
            if (!isTextActive)
            {
                _text.text = _message;
            }
        }
    }
}
