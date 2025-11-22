using UnityEngine;
using UnityEngine.UI;

public class BCollect : MonoBehaviour
{
    private CameraRayPoint _camRay;

    private Button _button;

    private string[] _tags = new string[]
    {
        "Botella",
        "Lata",
        "Bolsa",
        "Comida",
        "Papel"
    };

    void Start()
    {
        _camRay = FindObjectOfType<CameraRayPoint>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(TrashCollectable);

        _button.interactable = false;
    }

    void Update()
    {
        if (StaticTimer.IsFinished) return; // si se termina el tiempo ya no deja interactuar

        if (StaticAmount.IsFull) return; // Si la aspi esta llena no interactuar

        GameObject trash = _camRay.GetObjDetected();

        if (trash != null && IsValidTag(trash.tag))
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private bool IsValidTag(string tag)
    {
        for (int i = 0; i < _tags.Length; i++)
        {
            if (_tags[i] == tag)
                return true;
        }
        return false;
    }

    private void TrashCollectable()
    {
        if (StaticTimer.IsFinished) return; // si se termina el tiempo ya no deja interactuar

        if (StaticAmount.IsFull) return;  // Si la aspi esta llena no interactuar

        GameObject trash = _camRay.GetObjDetected();
        if (trash == null) return;

        float value = StaticAmount.GetValueByTag(trash);
        float spaceLeft = StaticAmount.GetMaxAmount() - StaticAmount.GetAmount();

        // Solo recolectar si cabe en el espacio restante
        if (value <= spaceLeft)
        {
            Debug.Log($"[BCollect] basura de tipo: {trash.tag} recolectada");

            StaticAmount.AddAmountByTag(trash);
            StaticScore.AddScoreByTag(trash);
            StaticSprite.AddSpriteByTag(trash);

            StaticStatistics.Recolectado();

            trash.SetActive(false);
        }
        else
        {
            Debug.Log($"[BCollect] basura de tipo: {trash.tag} NO recolectada, excede el espacio disponible ({spaceLeft}).");
        }


        /*Debug.Log($"[BCollect] basura de tipo: {trash.tag}  recolectada");

        // Añadir puntaje, amount y sprite correspondiente
        StaticAmount.AddAmountByTag(trash);
        StaticScore.AddScoreByTag(trash);
        StaticSprite.AddSpriteByTag(trash);

        // pa sumar a las estadisticas finales
        StaticStatistics.Recolectado();
        */
        // Desactivar el objeto
        //trash.SetActive(false);
    }
}