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
        GameObject trash = _camRay.GetObjDetected();

        // Actualizamos el estado del botón en tiempo real
        if (trash != null && trash.CompareTag("Trash"))
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void TrashCollectable()
    {
        GameObject trash = _camRay.GetObjDetected();

        // Seguridad extra
        if (trash == null || !trash.CompareTag("Trash"))
            return;


        TrashScore trashScore = trash.GetComponent<TrashScore>();

        if (trashScore != null)
        {
            StaticScoreTrash.AddScore(trashScore.GetScore());
        }

        // Acción del click
        trash.SetActive(false);
    }
}
