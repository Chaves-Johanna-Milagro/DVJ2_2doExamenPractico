using UnityEngine;

public class CameraRayPoint : MonoBehaviour
{
    private float _distance = 50f;

    private GameObject _obj;

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
            // Guardamos el obj mientras esté golpeado por el rayo
            if (_obj != hit.collider.gameObject)
            {
                _obj = hit.collider.gameObject;
                Debug.Log("Impactó: " + _obj.name);
            }
        }
        else
        {
            // Si NO hay impacto, reseteamos
            if (_obj != null)
            {
                Debug.Log("Salió del rayo, reseteando obj");
                _obj = null;
            }
        }
    }

    public GameObject GetObjDetected()
    {
        return _obj;
    }
}
