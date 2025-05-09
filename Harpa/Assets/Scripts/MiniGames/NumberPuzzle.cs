using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPuzzle : MonoBehaviour
{
    public Canvas _numberCanvas;
    public Canvas _inputCanvas;
    public Button[] _numberButtons;
    public Button _deleteButton;
    public Button _submitButton;
    public Text _numberText;
    public GameObject _puerta;

    public int[] _correctSequence = { 1, 2, 0, 6 };

    private List<int> _currentInput = new List<int>();
    private bool _isPlayerInTrigger = false;
    private bool _isGameOpen = false;

    private void Start()
    {
        _numberCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);

        for (int i = 0; i < _numberButtons.Length; i++)
        {
            int number = i + 1;
            if (number == 10) number = 0;
            _numberButtons[i].onClick.AddListener(() => AddNumber(number));
        }

        _deleteButton.onClick.AddListener(RemoveLastNumber);
        _submitButton.onClick.AddListener(CheckSequence);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
        _inputCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _numberCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
        _isPlayerInTrigger = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerInTrigger)
        {
            if (_isGameOpen)
            {
                _inputCanvas.gameObject.SetActive(true);
                _numberCanvas.gameObject.SetActive(false);
                _isGameOpen = false;
            }
            else
            {
                _inputCanvas.gameObject.SetActive(false);
                _numberCanvas.gameObject.SetActive(true);
                StartPuzzle();
                _isGameOpen = true;
            }
        }
    }

    void StartPuzzle()
    {
        _currentInput.Clear();
        UpdateDisplay();
    }

    public void AddNumber(int number)
    {
        if (_currentInput.Count < _correctSequence.Length)
        {
            _currentInput.Add(number);
            UpdateDisplay();
        }
    }

    public void RemoveLastNumber()
    {
        if (_currentInput.Count > 0)
        {
            _currentInput.RemoveAt(_currentInput.Count - 1);
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        _numberText.text = string.Join("", _currentInput);
        _numberText.color = Color.white; 
    }

    void CheckSequence()
    {
        if (_currentInput.Count != _correctSequence.Length)
        {
            StartCoroutine(ShowMessage("Incomplete", Color.red, 2f));
            return;
        }

        for (int i = 0; i < _correctSequence.Length; i++)
        {
            if (_currentInput[i] != _correctSequence[i])
            {
                StartCoroutine(ShowMessage("Incorrect", Color.red, 2f));
                StartPuzzle();
                return;
            }
        }

        StartCoroutine(ShowMessage("Completed", Color.green, 2f));
        GameCompleted();
    }

    private void GameCompleted()
    {
        _numberCanvas.gameObject.SetActive(false);
        Destroy(gameObject);
        Destroy(_puerta);
    }

    private IEnumerator ShowMessage(string message, Color color, float duration)
    {
        _numberText.text = message;
        _numberText.color = color;
        yield return new WaitForSeconds(duration);
        UpdateDisplay();

    }
}
