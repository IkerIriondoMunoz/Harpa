using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleOrden : MonoBehaviour
{
    public Canvas _orderCanvas;
    public Canvas _inputCanvas;
    public Button[] _buttons;
    private int _currentStep = 0;

    public int[] correctSequence = {1, 2, 3, 4, 5, 6, 7, 8};
    private bool _isPlayerInTrigger = false;

    private void Start()
    {
        _orderCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _orderCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
        _isPlayerInTrigger = false;
    }

    private void Update()
    {
        if (_isPlayerInTrigger)
        {
            _inputCanvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _inputCanvas.gameObject.SetActive(false);
                _orderCanvas.gameObject.SetActive(true);
                StarPuzzle();
            }
        }

    }

    void StarPuzzle()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;

            _buttons[i].onClick.AddListener(() =>
            {

                if (index == correctSequence[_currentStep])
                {
                    Debug.Log("Correcto: " + index);
                    _currentStep++;

                    if (_currentStep >= correctSequence.Length)
                    {
                        Debug.Log("¡Secuencia completada!");
                        _currentStep = 0;
                    }
                }
                else
                {
                    Debug.Log("Error. Reiniciando secuencia.");
                    _currentStep = 0;
                }
            });
        }
    }
}
