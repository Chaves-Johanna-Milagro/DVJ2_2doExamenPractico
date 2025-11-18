using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
public class TextDistance : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private ARPlaneManager _planeManager;

    private ARPlane _targetPlane;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        // Si aún no tenemos un plano asignado, tomamos el primero detectado
        if (_targetPlane == null)
        {
            foreach (var plane in _planeManager.trackables)
            {
                _targetPlane = plane;
                break;
            }
        }

        // Si hay plano, mostramos tamaño
        if (_targetPlane != null)
        {
            Vector2 size = _targetPlane.size;   // Esto está en metros reales
            float ancho = size.x;
            float largo = size.y;

            _text.text =
                $"Plane Detected\n" +
                $"Width: {ancho:F2} m\n" +
                $"Height: {largo:F2} m\n" +
                $"(Portrait)";
        }
        else
        {
            _text.text = "Buscando plano...";
        }
    }
}
