using UnityEngine;
using UnityEngine.UI;

public class InfoObject : MonoBehaviour
{
    public Canvas _textCanvas;
    public Canvas _inputCanvas;
    public Text _infoText;

    public string _infoTextContent;
    private bool _isPlayerInTrigger;
    private bool _isCanvasOpen;
    void Start()
    {
        _textCanvas.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
        _inputCanvas.gameObject.SetActive(true);

        _infoText.text = _infoTextContent;
    }

    private void OnTriggerExit(Collider other)
    {
        _textCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
        _isPlayerInTrigger = false;
    }

    void Update()
    {
        if (_isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (_isCanvasOpen)
            {
                _textCanvas.gameObject.SetActive(false);
                _inputCanvas.gameObject.SetActive(true);
                _isCanvasOpen = false;
            }
            else
            {
                _textCanvas.gameObject.SetActive(true);
                _inputCanvas.gameObject.SetActive(false);
                _isCanvasOpen = true;
            }
        }
    }
}
