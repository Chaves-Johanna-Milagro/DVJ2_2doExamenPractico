using UnityEngine;

public class ContainerSprite : MonoBehaviour
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
