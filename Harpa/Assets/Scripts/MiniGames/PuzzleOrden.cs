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

    public int[] _correctSequence = {0, 1, 2, 3, 4, 5, 6, 7};
    private bool _isPlayerInTrigger = false;
    private Color _color = Color.green;
    private Color _originalColor = new Color(164f/225f, 164f/225f, 164f/225f);
    public GameObject _puerta;
    private bool _isGameOpen = false;

    public SC_ThirdPersonMovement player;


    private void Start()
    {
        _orderCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInTrigger = true;
            _inputCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _orderCanvas.gameObject.SetActive(false);
            _inputCanvas.gameObject.SetActive(false);
            _isPlayerInTrigger = false;
            player.cursorLockUnlock(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerInTrigger)
        {            
            if (_isGameOpen)
            {
                _inputCanvas.gameObject.SetActive(true);
                _orderCanvas.gameObject.SetActive(false);
                _isGameOpen = false;

                player.cursorLockUnlock(true);
            }
            else
            {
                _inputCanvas.gameObject.SetActive(false);
                _orderCanvas.gameObject.SetActive(true);
                StartPuzzle();
                _isGameOpen = true;

                player.cursorLockUnlock(false);

            }
        }
    }

    void StartPuzzle()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;

            _buttons[i].onClick.RemoveAllListeners();

            _buttons[i].onClick.AddListener(() =>
            {

                if (index == _correctSequence[_currentStep])
                {
                    Debug.Log("Correcto: " + index);
                    _currentStep++;
                    _buttons[index].image.color = _color;
                    _color = Color.green;

                    if (_currentStep >= _correctSequence.Length)
                    {
                        Debug.Log("¡Secuencia completada!");
                        _currentStep = 0;
                        GameCompleted();
                    }
                }
                else
                {
                    Debug.Log("Error. Reiniciando secuencia.");
                    _currentStep = 0;

                    foreach (var button in _buttons)
                    {
                        button.image.color = _originalColor;
                    }
                }
            });
        }
    }

    private void GameCompleted()
    {
        _orderCanvas.gameObject.SetActive(false);
        Destroy(gameObject);
        Destroy(_puerta);

        player.cursorLockUnlock(true);

    }
}
