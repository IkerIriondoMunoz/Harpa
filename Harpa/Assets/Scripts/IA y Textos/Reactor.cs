using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reactor : MonoBehaviour
{
    public Canvas canvasInput;
    public Text _text;
    public GameObject _player;
    private bool isPlayerInTrigger = false;

    void Start()
    {
        canvasInput.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            canvasInput.gameObject.SetActive(true);
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            canvasInput.gameObject.SetActive(false);
            isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
            Debug.Log("cagando escena");
        }
    }
}

