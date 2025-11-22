using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BDrop : MonoBehaviour
{
    private CameraRayPoint _camRay;

    private Image _image;
    private Button _button;

    private string[] _tags = new string[]
    {
        "Botella",
        "Lata",
        "Bolsa",
        "Comida",
        "Papel"
    };

    private int _currentSpriteIndex = 0;
    private List<Sprite> _sprites;

    private Sprite _default; // Pa cuando se le acabe la basura vuelva al blanco
    void Start()
    {
        _camRay = FindObjectOfType<CameraRayPoint>();

        _image = GetComponent<Image>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(TrashDropiable);

        _button.interactable = false;
        _sprites = StaticSprite.GetSprites();

        if (_sprites.Count > 0)
        {
            _image.sprite = _sprites[0];
        }
    }
    void Update()
    {
        if (StaticTimer.IsFinished) return; // si se termina el tiempo ya no deja interactuar

        if (StaticAmount.IsEmpty) return; // Si la aspi esta vacia no interactuar

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
    private void TrashDropiable()
    {
        if (StaticTimer.IsFinished) return; // si se termina el tiempo ya no deja interactuar

        if (StaticAmount.IsEmpty) return;  // Si la aspi esta vacia no interactuar

        GameObject trash = _camRay.GetObjDetected();
        if (trash == null) return;

        Debug.Log($"[BDrop] basura de tipo: {trash.tag}  dropeada");

        // Siempre restar cantidad
        StaticAmount.RestAmount(trash);

        // Si NO coincide con el sprite actual, restar score
        if (_image.sprite == null || trash.tag != _image.sprite.name)
        {
            StaticScore.RestScore(trash);
            Debug.Log($"[BDrop] Tag {trash.tag} no coincide con sprite {_image.sprite?.name}, se resta score.");
        }
        if (_image.sprite == null || trash.tag == _image.sprite.name)
        {
            StaticScore.AddScoreByTag(trash);
            Debug.Log($"[BDrop] Tag {trash.tag} coincide con sprite {_image.sprite?.name}, se suma score.");
        }

        // Avanzar al siguiente sprite
        _currentSpriteIndex++;
        if (_currentSpriteIndex < _sprites.Count)
        {
            _image.sprite = _sprites[_currentSpriteIndex];
        }
        else
        {
            _image.sprite = _default;
            _button.interactable = false;
            Debug.Log("[BDrop] Se acabaron los sprites, botón desactivado.");
        }

    }
}
