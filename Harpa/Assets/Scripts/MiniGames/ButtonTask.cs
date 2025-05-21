using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTask : MonoBehaviour
{
    public Canvas _gameCanvas;
    public Canvas _inputCanvas;

    public Image _progressBar;
    public Button _fillButton;
    public float _fillSpeed = 0.011f;

    private bool _isBarFull = false;

    public GameObject _puerta;
    public GameObject _nextBar;
    public GameObject _completedLight;
    public GameObject _uncompletedLight;

    public SC_ThirdPersonMovement player;

    public Image _rivalBar;
    public float _rivalFillSpeed = 0.01f;

    private bool _isPlayerInTrigger;
    private bool _isGameOpen;
    private float _rivalTimer = 0f;

    void Start()
    {
        _completedLight.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
        _fillButton.onClick.AddListener(StartPuzzle);
        _progressBar.fillAmount = 0f;
        _rivalBar.fillAmount = 0f;
        _nextBar.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
        _inputCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _gameCanvas.gameObject.SetActive(false);
        _inputCanvas.gameObject.SetActive(false);
        _isPlayerInTrigger = false;
        player.cursorLockUnlock(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerInTrigger)
        {
            if (_isGameOpen)
            {
                _inputCanvas.gameObject.SetActive(true);
                _gameCanvas.gameObject.SetActive(false);
                _isGameOpen = false;

                _inputCanvas.gameObject.SetActive(true);

                player.cursorLockUnlock(true);
            }
            else
            {
                _inputCanvas.gameObject.SetActive(false);
                _gameCanvas.gameObject.SetActive(true);
                StartPuzzle();
                _isGameOpen = true;
                ResetPuzzle();

                _inputCanvas.gameObject.SetActive(false);

                player.cursorLockUnlock(false);
            }
        }

        if (_isGameOpen)
        {
            UpdateRival();
        }
    }

    void ResetPuzzle()
    {
        _progressBar.fillAmount = 0f;
        _rivalBar.fillAmount = 0f;
        _isBarFull = false;
    }

    void UpdateRival()
    {
        _rivalTimer += Time.deltaTime;
        if (_rivalTimer >= 0.2f)
        {
            if (_rivalBar.fillAmount < 1f)
            {
                _rivalBar.fillAmount = _rivalBar.fillAmount + _rivalFillSpeed;
            }
            _rivalTimer = 0f;
        }

        if (_rivalBar.fillAmount >= 1f && _progressBar.fillAmount <= 1f)
        {
            _progressBar.fillAmount = 0f;
            _rivalBar.fillAmount = 0f;
            Debug.Log("Sobrecalentamiento, vuelva a probar");
        }
    }

    void StartPuzzle()
    {
        if (_progressBar.fillAmount < 1f)
        {
            _progressBar.fillAmount += _fillSpeed;
        }

        if (_progressBar.fillAmount >= 1f && !_isBarFull)
        {
            _isBarFull = true;
            GameCompleted();
        }
    }

    void GameCompleted()
    {
        player.cursorLockUnlock(true);

        _completedLight.gameObject.SetActive(true);
        _uncompletedLight.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        Destroy(_puerta);
        _gameCanvas.gameObject.SetActive(false);
        _nextBar.gameObject.SetActive(true);

        _inputCanvas.gameObject.SetActive(true);

        
    }
}