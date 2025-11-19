using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BStorage : MonoBehaviour
{
    private Image _bar;

    private Button _b;

    private string _reco = "Recoleccion";
    private string _clas = "Clasificacion";

    void Start()
    {
        _bar = GetComponent<Image>();
        _b = transform.Find("Button").GetComponent<Button>();

        _b.onClick.AddListener(ChangeMood);

    }

    void Update()
    {
        /* if (!StaticAmountTrash.IsFull)
         {
             _b.interactable = false;
         }

         if (StaticAmountTrash.IsFull)
         {
             Debug.Log("STORAGE FULL: No se puede recolectar más basura");

             _b.interactable = true;
             return;
         }*/



        float current = StaticAmountTrash.GetAmount();
        float max = StaticAmountTrash.GetMaxAmount();

        float percent = current / max;
        percent = Mathf.Clamp01(percent);

        _bar.fillAmount = percent;

        // En recolección el botón solo funciona si está lleno
        if (SceneManager.GetActiveScene().name == _reco)
        {
            _b.interactable = StaticAmountTrash.IsFull;
        }
        else // estás en clasificación
        {
            _b.interactable = (current <= 0f);
        }


    }

    private void ChangeMood()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene == _reco && StaticAmountTrash.IsFull)
        {
            SceneManager.LoadScene(_clas);
        }
        else if (scene == _clas && StaticAmountTrash.GetAmount() <= 0f)
        {
            SceneManager.LoadScene(_reco);
        }
    }
}
