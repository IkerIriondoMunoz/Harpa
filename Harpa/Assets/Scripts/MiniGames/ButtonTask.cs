using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTask : MonoBehaviour
{
    public Image progressBar; // Imagen que representa la barra de progreso
    public Button fillButton; // Botón para llenar la barra
    public float fillSpeed = 0.1f; // Velocidad de llenado

    private bool isBarFull = false; // Bandera para evitar múltiples llamadas al método

    public GameObject EliminarJuego; // Primer GameObject a desactivar
    public GameObject AbrirPuerta; // Segundo GameObject a desactivar
    public Canvas canvasMinijuego; // Referencia al Canvas del minijuego

    void Start()
    {
        fillButton.onClick.AddListener(FillProgress); // Asigna el evento al botón
        progressBar.fillAmount = 0f; // Inicia vacía
    }

    void FillProgress()
    {
        if (progressBar.fillAmount < 1f) // Si no está llena
        {
            progressBar.fillAmount += fillSpeed; // Aumenta el progreso
        }

        // Verificar si la barra está llena y llamar al método
        if (progressBar.fillAmount >= 1f && !isBarFull)
        {
            isBarFull = true; // Marcar como llena para evitar múltiples llamadas
            CerrarPuzzle(); // Llamar al método cuando la barra esté llena
        }
    }

    // Método que se llama cuando la barra está llena
    void CerrarPuzzle()
    {
        Debug.Log("Cerrando puzzle...");

        // Desactivar los dos GameObjects
        if (EliminarJuego != null)
        {
            Collider collider = EliminarJuego.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Desactiva el collider
            }
        }

        if (AbrirPuerta != null)
        {
            AbrirPuerta.SetActive(false);
        }

        // Desactivar el Canvas del minijuego
        if (canvasMinijuego != null)
        {
            canvasMinijuego.gameObject.SetActive(false);
        }
    }
}

