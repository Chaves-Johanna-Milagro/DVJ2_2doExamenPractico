using UnityEngine;
using UnityEngine.UI;

public class BCollectTrash : MonoBehaviour
{
    private CameraRayPoint _camRay;

    private Button _button;
    void Start()
    {
        _camRay = FindObjectOfType<CameraRayPoint>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(TrashCollectable);
    }

    void Update()
    {
        if (StaticTimer.IsFinished) return; // si se termina el tiempo ya no deja interactuar

        GameObject trash = _camRay.GetObjDetected();

        // Actualizamos el estado del botón en tiempo real
        if (trash != null && trash.CompareTag("Trash"))
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void TrashCollectable()
    {
        if (StaticAmountTrash.IsFull) return; // si se llenó la aspiradora, no recoger

        GameObject trash = _camRay.GetObjDetected();

        // Seguridad extra
        if (trash == null || !trash.CompareTag("Trash"))
            return;


        TrashScore trashScore = trash.GetComponent<TrashScore>();

        if (trashScore != null)
        {
            StaticScoreTrash.AddScore(trashScore.GetScore());
        }

        TrashAmount trashAmount = trash.GetComponent<TrashAmount>();

        if (trashAmount != null)
        {
            StaticAmountTrash.AddAmount(trashAmount.GetAmount());
        }

        TrashSprite trashSprite = trash.GetComponent<TrashSprite>();

        if (trashAmount != null)
        {
            StaticSpriteTrash.AddSprite(trashSprite.GetSprite());
        }

        // Acción del click
        trash.SetActive(false);
    }
}
