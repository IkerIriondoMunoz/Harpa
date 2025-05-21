using Unity.Cinemachine;
using UnityEngine;

public class OpenMiniGame : MonoBehaviour
{
    public Canvas canvasMinigame; // Canvas del minijuego
    public Canvas canvasInput;   // Canvas de entrada (instrucciones)
    public GameObject player;    // Objeto del jugador
    public CinemachineCamera cinemachineCamera; // Cámara Cinemachine

    private bool isPlayerInTrigger = false;

    void Start()
    {
        // Desactivar ambos Canvas al inicio
        canvasMinigame.gameObject.SetActive(false);
        canvasInput.gameObject.SetActive(false);

        // Asegurarse de que la cámara esté activa al inicio
        if (cinemachineCamera != null)
        {
            cinemachineCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            // Mostrar el Canvas de instrucciones
            canvasInput.gameObject.SetActive(true);
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            // Ocultar ambos Canvas al salir del trigger
            canvasMinigame.gameObject.SetActive(false);
            canvasInput.gameObject.SetActive(false);
            isPlayerInTrigger = false;

            // Reactivar la cámara al salir del trigger
            if (cinemachineCamera != null)
            {
                cinemachineCamera.gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        // Verificar si el canvasMinigame existe y está activo
        if (canvasMinigame == null || !canvasMinigame.gameObject.activeSelf)
        {
            // Si el canvasMinigame no existe o está desactivado, reactivar la cámara
            if (cinemachineCamera != null)
            {
                cinemachineCamera.gameObject.SetActive(true);
            }
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Alternar entre mostrar/ocultar el Canvas del minijuego
            bool isMinigameActive = canvasMinigame.gameObject.activeSelf;
            canvasMinigame.gameObject.SetActive(!isMinigameActive);
            canvasInput.gameObject.SetActive(isMinigameActive);

            // Activar/desactivar la cámara según el estado del minijuego
            if (cinemachineCamera != null)
            {
                cinemachineCamera.gameObject.SetActive(isMinigameActive);
            }
        }
    }
}