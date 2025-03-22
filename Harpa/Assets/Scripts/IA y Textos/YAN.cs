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

    void Start()
    {
        canvasYan.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasYan.gameObject.SetActive(true);
            canvasTextYan.text = yanText;
        }

        if (yanAudioSource != null && yanClip != null)
        {
            yanAudioSource.PlayOneShot(yanClip);
        }

        gameObject.SetActive(false);
    }
}
