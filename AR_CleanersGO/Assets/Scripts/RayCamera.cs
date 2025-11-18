using UnityEngine;

public class RayCamera : MonoBehaviour
{
    private float _distance = 50f;

    private BCollectTrash _bCollect;

    private GameObject _currentTrash;

    private void Start()
    {
        _bCollect = FindObjectOfType<BCollectTrash>();

    }
    void Update()
    {
        // Dirección hacia adelante desde la cámara
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // Dibuja rayo visible en Scene View
        Debug.DrawRay(origin, direction * _distance, Color.green);

        // Detectar el objeto golpeado
        if (Physics.Raycast(origin, direction, out RaycastHit hit, _distance))
        {
            Debug.Log("Impactó: " + hit.collider.name);

            _bCollect.TrashInPoint(false);

            if (hit.collider.tag == "Trash")
            {
                // Habilita el botón
                _bCollect.TrashInPoint(true);

                // Guarda referencia del objeto
                _currentTrash = hit.collider.gameObject;

                // Le dice al botón qué objeto debe desactivar
                _bCollect.SetCurrentTrash(_currentTrash);
            }
        }
    }
}

