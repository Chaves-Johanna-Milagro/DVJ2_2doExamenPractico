using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BDropTrash : MonoBehaviour
{
    private CameraRayPoint _camRay;

    private Button _button;
    private Image _image;

    private int _currentSpriteIndex = 0;
    private List<Sprite> _sprites;

    void Start()
    {
        _camRay = FindObjectOfType<CameraRayPoint>();

        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

        _button.onClick.AddListener(SwitchSprite);

        // Cargamos sprites existentes al iniciar
        _sprites = StaticSpriteTrash.GetSprites();

        if (_sprites.Count > 0)
        {
            _image.sprite = _sprites[0];
        }
    }

    void Update()
    {
        GameObject obj = _camRay.GetObjDetected();

        // Solo se puede interactuar si mirás un Container
        if (obj != null && obj.CompareTag("Container"))
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void SwitchSprite()
    {
        GameObject obj = _camRay.GetObjDetected();

        // Seguridad extra
        if (obj == null || !obj.CompareTag("Container"))
            return;

        _sprites = StaticSpriteTrash.GetSprites();

        if (_sprites.Count == 0)
            return;

        _currentSpriteIndex++;

        if (_currentSpriteIndex >= _sprites.Count)
            _currentSpriteIndex = 0;

        _image.sprite = _sprites[_currentSpriteIndex];

        Debug.Log("Sprite cambiado → " + _image.sprite.name);
    }
}
