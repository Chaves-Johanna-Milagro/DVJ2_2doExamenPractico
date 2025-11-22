using UnityEngine;

public class ImageScale : MonoBehaviour
{
    private Vector3 _originalScale;
    private Vector3 _bigScale;

    private float _speed = 4f;     // qué tan rápido se anima
    private bool _growing = true;  // si está agrandándose o achicándose

    private void Start()
    {
        _originalScale = transform.localScale;
        _bigScale = _originalScale * 1.2f; // tamaño grande momentáneo
    }

    private void Update()
    {
        if (_growing)
        {
            // crecer
            transform.localScale = Vector3.Lerp(transform.localScale, _bigScale, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.localScale, _bigScale) < 0.01f)
                _growing = false;
        }
        else
        {
            // volver al tamaño original
            transform.localScale = Vector3.Lerp(transform.localScale, _originalScale, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.localScale, _originalScale) < 0.01f)
                _growing = true;
        }
    }
}
