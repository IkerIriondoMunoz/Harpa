using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondC : MonoBehaviour
{
    public float speed = 100f;
    public float rotationSpeed = 30f;
    public float strafeSpeed = 5f;
    private float timer = 0f;
    private bool startTurning = false;
    private float rotatedDegrees = 0f;
    public int _nextScene;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= 1f && rotatedDegrees < 90f)
        {
            startTurning = true;
        }

        if (startTurning)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            if (rotatedDegrees + rotationThisFrame > 90f)
            {
                rotationThisFrame = 90f - rotatedDegrees;
                startTurning = false;
            }

            transform.Rotate(Vector3.up * rotationThisFrame);
            transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime, Space.World);
            rotatedDegrees += rotationThisFrame;
        }

        if (timer >= 5f)
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
