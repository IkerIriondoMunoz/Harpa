using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelTask : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI papel;

    public AudioClip approved;
    public AudioClip denied;

    private AudioSource audioSource;

    public GameObject EliminarJuego; // Primer GameObject a desactivar
    public GameObject AbrirPuerta; // Segundo GameObject a desactivar
    public Canvas canvasMinijuego; // Referencia al Canvas del minijuego

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GeneratePassword();
    }

    public void AddNumber(string number)
    {
        if (display.text.Length >= 4)
        {
            return;
        }

        display.text += number;
    }

    public void EraseDisplay()
    {
        display.text = "";
    }

    private void GeneratePassword()
    {
        papel.text = "";

        for (int i = 0; i < 4; i++)
        {
            int randNumber = UnityEngine.Random.Range(1, 9);
            papel.text += randNumber;
        }
    }

    public void CheckPassword()
    {
        if (display.text.Equals(papel.text))
        {
            audioSource.PlayOneShot(approved);
            display.color = Color.green;
            display.text = "Granted";
            CerrarPuzzle();
        }
        else
        {
            audioSource.PlayOneShot(denied);
            display.text = "Denied";
        }
    }
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
