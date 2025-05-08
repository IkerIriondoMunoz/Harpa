using UnityEngine;
using UnityEngine.UI;

public class PhotoRotate : MonoBehaviour
{
    public Canvas _photoCanvas;
    public Canvas _inputCanvas;
    public Image _photoImageA;
    public Image _photoImageB;
    private bool _isPlayerInTrigger;
    private bool _isCanvasOpen;
    private bool _photoCaraA;
    
    void Start()
    {
       _photoCanvas.gameObject.SetActive(false);
        _photoImageA.gameObject.SetActive(true);
        _photoImageB.gameObject.SetActive(false);
        _photoCaraA = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
        _inputCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _photoCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
        _isPlayerInTrigger = false;
    }

    private void Update()
    {
        if (_isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (_isCanvasOpen)
            {
                _photoCanvas.gameObject.SetActive(false);
                _inputCanvas.gameObject.SetActive(true);
                _isCanvasOpen = false;
            }
            else
            {
                _photoCanvas.gameObject.SetActive(true);
                _inputCanvas.gameObject.SetActive(false);
                _isCanvasOpen = true;
            }
        }

        if (_isCanvasOpen && _isPlayerInTrigger && Input.GetKeyDown(KeyCode.T))
        {
            if (_photoCaraA)
            {
                _photoCaraA = false;
                _photoImageA.gameObject.SetActive(false);
                _photoImageB.gameObject.SetActive(true);
            }
            else
            {
                _photoCaraA = true;
                _photoImageA.gameObject.SetActive(true);
                _photoImageB.gameObject.SetActive(false);
            }
        }
    }
}
