using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    public Canvas canvasText;
    public Text _text;
    public string _message;

    void Start()
    {
        canvasText.gameObject.SetActive(false);
    }

    void Update()
    {
       if (Input.GetKey(KeyCode.E))
        {
            canvasText.gameObject.SetActive(true);
            _text.text = _message;
        }
       if (Input.GetKey(KeyCode.E))
        {
            canvasText.gameObject.SetActive(false);
        }
    }
}
