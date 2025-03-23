using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class YAN : MonoBehaviour
{
    public Canvas canvasYan;
    public Text canvasTextYan;
    public string yanText;
    public AudioSource yanAudioSource;
    public AudioClip yanClip;
    public float disableTime = 3f;
    private float tiempoInicial = 0f;

    void Start()
    {
        canvasYan.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tiempoInicial += Time.deltaTime;
            canvasYan.gameObject.SetActive(true);
            canvasTextYan.text = yanText;
        }

        if (yanAudioSource != null && yanClip != null)
        {
            yanAudioSource.PlayOneShot(yanClip);
        }

        if (tiempoInicial >= disableTime)
        {
            canvasYan.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }

}
