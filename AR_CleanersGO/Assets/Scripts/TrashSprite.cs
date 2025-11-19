using UnityEngine;


// Se encargara de objeter los sprites que tengan las basuras 3D
// Pa luego cuando tengan que ser clasificados
public class TrashSprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        // Obtenemos el SpriteRenderer
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (_spriteRenderer == null)
        {
            Debug.LogError($"{gameObject.name} no tiene un SpriteRenderer.");
            return;
        }

        // Obtenemos el sprite
        Sprite mySprite = _spriteRenderer.sprite;

        if (mySprite == null)
        {
            Debug.LogWarning($"{gameObject.name} no tiene un sprite asignado.");
            return;
        }

        // Lo agregamos a SpriteStorage
        StaticSpriteTrash.AddSprite(mySprite);
    }
}
