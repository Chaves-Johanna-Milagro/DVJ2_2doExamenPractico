using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGoClasification : MonoBehaviour
{
    private Button _bClasification;

    void Start()
    {
        _bClasification = GetComponent<Button>();
        _bClasification.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Clasificacion");
        });
    }

    
}
