using System.Collections.Generic;
using UnityEngine;

public static class StaticSpriteTrash
{
    // Lista interna donde guardamos los sprites en el orden que llegan
    private static List<Sprite> _sprites = new List<Sprite>();

    /// <summary>
    /// Agrega un sprite a la lista.
    /// </summary>
    public static void AddSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            Debug.LogWarning("Intentaste agregar un sprite null.");
            return;
        }

        _sprites.Add(sprite);
    }

    /// <summary>
    /// Devuelve todos los sprites en el mismo orden en que fueron agregados.
    /// </summary>
    public static List<Sprite> GetSprites()
    {
        // Devolvemos una copia para que desde afuera no modifiquen la lista interna
        return new List<Sprite>(_sprites);
    }
}
