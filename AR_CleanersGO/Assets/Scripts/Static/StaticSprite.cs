using System.Collections.Generic;
using UnityEngine;

public static class StaticSprite
{
    private static List<Sprite> _sprites = new List<Sprite>();
    private static Sprite[] _resourcesSprites;

    // Llama a esto UNA vez al iniciar el juego
    public static void LoadSpritesFromResources()
    {
        _resourcesSprites = Resources.LoadAll<Sprite>("Sprites");

        if (_resourcesSprites == null || _resourcesSprites.Length == 0)
        {
            Debug.Log("[StaticSprite] No se encontraron sprites en Resources/Sprites");
        }
    }

    // Recibe un GameObject. Si el tag coincide con un sprite en Resources, lo añade.
    public static void AddSpriteByTag(GameObject obj)
    {
        if (_resourcesSprites == null)
        {
            Debug.Log("[StaticSprite] Primero llamá LoadSpritesFromResources() antes de usar AddSpriteByTag()");
            return;
        }

        string tagName = obj.tag;

        foreach (var sp in _resourcesSprites)
        {
            if (sp.name == tagName)
            {
                _sprites.Add(sp); // ➜ Permite AÑADIR DUPLICADOS
                return;
            }
        }

        Debug.Log("[StaticSprite] No existe un sprite llamado '" + tagName + "' en Resources cargados.");
    }

    // Devuelve los sprites EXACTAMENTE en el orden en que se fueron añadiendo
    public static List<Sprite> GetSprites()
    {
        Debug.Log($"[StaticSprite] Cantidad de sprites añadidos {_sprites.Count}");
        return _sprites;
    }
    // Limpiar la lista cada que se terminen de dropear
    public static void ClearSprites()
    {
        _sprites.Clear();
        Debug.Log("[StaticSprite] Lista de sprites limpiada.");
    }


}
