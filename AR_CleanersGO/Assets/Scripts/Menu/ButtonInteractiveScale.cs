using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractiveScale : MonoBehaviour
{
    private Button _button;

    private Vector3 _originalScale;
    private Vector3 _enabledScale;

    private float _speed = 6f;

    private void Start()
    {
        _button = GetComponent<Button>();

        _originalScale = transform.localScale;
        _enabledScale = _originalScale * 1.15f; // tamaño cuando está activo
    }

    private void Update()
    {
        if (_button.interactable)
        {
            // Escalar hacia grande
            transform.localScale = Vector3.Lerp(transform.localScale, _enabledScale, Time.deltaTime * _speed);
        }
        else
        {
            // Volver a escala original
            transform.localScale = Vector3.Lerp(transform.localScale, _originalScale, Time.deltaTime * _speed);
        }
    }
}
