using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class YAN : MonoBehaviour
{
    public Canvas canvasYan;
    public Text canvasTextYan;
    public string yanText;
    public AudioSource yanAudioSource;
    public AudioClip yanClip;
    public float disableTime = 3f;

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
            StartCoroutine(DisableCanvasAfterTime());
        }

        if (yanAudioSource != null && yanClip != null)
        {
            yanAudioSource.PlayOneShot(yanClip);
        }

        gameObject.SetActive(false);
    }

    private IEnumerator DisableCanvasAfterTime()
    {
        yield return new WaitForSeconds(disableTime);
        if (canvasYan != null)
        {
            canvasYan.gameObject.SetActive(false);
        }
    }
}
