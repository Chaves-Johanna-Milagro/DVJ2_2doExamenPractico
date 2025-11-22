using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 _originalScale;
    private Vector3 _pressedScale;

    private void Start()
    {
        _originalScale = transform.localScale;
        _pressedScale = _originalScale * 1.1f; // Tamaño al presionar
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = _pressedScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = _originalScale;
    }
}
