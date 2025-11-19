using UnityEngine;


// Se encargara de objeter los sprites que tengan las basuras 3D
// Pa luego cuando tengan que ser clasificados
public class TrashSprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private Sprite _sprite;

    private void Start()
    {
        // Obtenemos el SpriteRenderer
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _sprite = _spriteRenderer.sprite;
    }

    public Sprite GetSprite()
    {
        return _sprite;
    }
}
