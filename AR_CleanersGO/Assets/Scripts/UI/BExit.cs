using UnityEngine;
using UnityEngine.UI;

public class BExit : MonoBehaviour
{
    private Button _bExit;
    void Start()
    {
        _bExit = GetComponent<Button>();
        _bExit.onClick.AddListener(() =>
        {
            Application.Quit();

            Debug.Log("Saliendo del juego...");
        });
    }

 
}
