using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BStorage : MonoBehaviour
{
    private Image _bar;

    private Button _b;

    private string _clasi = "Clasificacion";
    void Start()
    {
        _bar = GetComponent<Image>();
        _b = transform.Find("Button").GetComponent<Button>();

        _b.onClick.AddListener( () =>
        {
            SceneManager.LoadScene(_clasi);
            Debug.Log("llendo a la escena clasificacion");
        });


    }

    void Update()
    {
        if (!StaticAmountTrash.IsFull)
        {
            _b.interactable = false;
        }

        if (StaticAmountTrash.IsFull)
        {
            Debug.Log("STORAGE FULL: No se puede recolectar más basura");

            _b.interactable = true;
            return;
        }

        float current = StaticAmountTrash.GetAmount();
        float max = StaticAmountTrash.GetMaxAmount();

        float percent = current / max;
        percent = Mathf.Clamp01(percent);

        _bar.fillAmount = percent;

    }
}
