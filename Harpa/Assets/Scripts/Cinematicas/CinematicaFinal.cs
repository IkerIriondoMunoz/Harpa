using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaFinal : MonoBehaviour
{
    public int _nextScene;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
