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

        UpdateBar();        // Muestra valor al inicio
        UpdateInteractable();
    }

    void Update()
    {
        // Solo actualiza si StaticAmount cambió en el frame
        if (StaticAmount.AmountChanged)
        {
            UpdateBar();
            UpdateInteractable();
            StaticAmount.ResetFlag();
        }
    }

    private void UpdateBar()
    {
        float current = StaticAmount.GetAmount();
        float max = StaticAmount.GetMaxAmount();

        _bar.fillAmount = Mathf.Clamp01(current / max);
    }

    private void UpdateInteractable()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene == _reco)
        {
            _b.interactable = StaticAmount.IsFull;
        }
        else
        {
            _b.interactable = StaticAmount.IsEmpty;
        }
    }

    private void ChangeMood()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene == _reco && StaticAmount.IsFull)
        {
            SceneManager.LoadScene(_clas);
        }
        else if (scene == _clas && StaticAmount.IsEmpty)
        {
            SceneManager.LoadScene(_reco);
        }
    }
}
