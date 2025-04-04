using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class PuzzleNumerico : MonoBehaviour
{
    public List<Button> botones; // Lista de botones asignados en el inspector
    private int[] numeros; // Array de números aleatorios
    private int indiceActual = 1; // Número que debe presionar el jugador


    public GameObject EliminarJuego; // Primer GameObject a desactivar
    public GameObject AbrirPuerta; // Segundo GameObject a desactivar
    public Canvas canvasMinijuego; // Referencia al Canvas del minijuego


    void Start()
    {
        InicializarPuzzle();
    }

    void InicializarPuzzle()
    {
        indiceActual = 1; // Se reinicia el contador
        numeros = Enumerable.Range(1, 8).OrderBy(n => Random.value).ToArray(); // Genera números del 1 al 8 en orden aleatorio

        for (int i = 0; i < botones.Count; i++)
        {
            int numeroAsignado = numeros[i];
            botones[i].GetComponentInChildren<Text>().text = numeroAsignado.ToString(); // Muestra el número en el botón
            botones[i].onClick.RemoveAllListeners(); // Elimina eventos previos
            botones[i].onClick.AddListener(() => ComprobarNumero(numeroAsignado)); // Asigna la función con el número correspondiente
        }
    }

    void ComprobarNumero(int numeroPresionado)
    {
        if (numeroPresionado == indiceActual)
        {
            indiceActual++;
            if (indiceActual > 8)
            {
                Debug.Log("¡Puzzle completado!");
                CerrarPuzzle();
            }
        }
        else
        {
            Debug.Log("¡Fallaste! Reiniciando puzzle...");
            InicializarPuzzle();
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
