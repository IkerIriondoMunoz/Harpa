using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 30f;
    public float resetDelay = 1f;

    private RectTransform rectTransform;
    private Vector2 startPos;
    private float height;

    public int _nextScene;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
        height = rectTransform.rect.height;
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y >= height)
        {
            StartCoroutine(ResetCredits());
        }
    }

    System.Collections.IEnumerator ResetCredits()
    {
        yield return new WaitForSeconds(resetDelay);
        rectTransform.anchoredPosition = startPos;
    }

    public void Volver()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
