using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgTrashCollected : MonoBehaviour
{
    private List<Sprite> _sprites;
    private Button[] _childButtons;

    private void Start()
    {
        // Obtener los sprites en el orden en que fueron agregados
        _sprites = StaticSpriteTrash.GetSprites();

        // Obtener todos los botones hijos
        _childButtons = GetComponentsInChildren<Button>(includeInactive: true);

        // Si hay menos sprites que botones, usar solo los necesarios
        int count = Mathf.Min(_sprites.Count, _childButtons.Length);

        for (int i = 0; i < count; i++)
        {
            Image img = _childButtons[i].GetComponent<Image>();

            if (img == null)
            {
                Debug.LogError($"El hijo {i} no tiene un componente Image.");
                continue;
            }

            // Asignar el sprite correspondiente
            img.sprite = _sprites[i];

            // Guardar índice del botón para la función del click
            int index = i;

            _childButtons[i].onClick.AddListener(() => OnButtonClicked(index));
        }

        // Activar solo el primer botón
        ActivateOnlyButton(0);
    }

    private void OnButtonClicked(int index)
    {
        // Desactivar el botón actual
        _childButtons[index].gameObject.SetActive(false);

        // Activar el siguiente si existe
        int next = index + 1;

        if (next < _childButtons.Length)
        {
            _childButtons[next].gameObject.SetActive(true);
        }

        Debug.Log(_childButtons[index].gameObject.name);
    }

    private void ActivateOnlyButton(int index)
    {
        for (int i = 0; i < _childButtons.Length; i++)
        {
            _childButtons[i].gameObject.SetActive(i == index);
        }
    }
}
