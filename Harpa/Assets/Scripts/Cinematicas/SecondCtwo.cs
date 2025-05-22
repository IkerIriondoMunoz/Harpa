using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondCtwo : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float duration = 5f;
    public int _nextScene;

    private float elapsedTime = 0f;
    private bool sceneLoaded = false;

    void Start()
    {
        if (startPoint != null)
        {
            transform.position = startPoint.position;
            transform.rotation = startPoint.rotation;
        }
    }

    void Update()
    {
        if (startPoint == null || endPoint == null) return;

        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
            transform.rotation = Quaternion.Slerp(startPoint.rotation, endPoint.rotation, t);
        }
        else if (!sceneLoaded)
        {
            sceneLoaded = true;
            SceneManager.LoadScene(_nextScene);
        }
    }
}
