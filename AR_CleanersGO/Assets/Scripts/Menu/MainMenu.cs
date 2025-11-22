using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Button _bPlay;
    private Button _bExit;

    void Start()
    {
        _bPlay = transform.Find("BPlay").GetComponent<Button>();
        _bExit = transform.Find("BExit").GetComponent<Button>();

        _bPlay.onClick.AddListener( () =>
        {
            SceneManager.LoadScene("Recoleccion");

            Debug.Log("Cargando escena Recoleccion...");
        });

        _bExit.onClick.AddListener(() =>
        {
            Application.Quit();

            Debug.Log("Saliendo del juego...");
        });
    }


}
