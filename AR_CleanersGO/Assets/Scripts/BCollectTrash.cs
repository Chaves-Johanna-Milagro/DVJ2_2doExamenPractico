using UnityEngine;
using UnityEngine.UI;

public class BCollectTrash : MonoBehaviour
{
    private Button _button;

    private GameObject _currentTrash;
    private bool _collectable;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Collectable);
    }

    // Desde el raycast enviamos el objeto detectado
    public void SetCurrentTrash(GameObject trash)
    {
        _currentTrash = trash;
        _collectable = true;
    }

    // Para deshabilitar el botón si no hay objeto
    public void TrashInPoint(bool point)
    {
        _button.interactable = point;
        _collectable = point;
    }

    private void Collectable()
    {
        if (!_collectable) return;

        Debug.Log("Colectado: " + _currentTrash.name);

        // Apagar objeto
        _currentTrash.SetActive(false);

        // Evitar pulsar otra vez
        _collectable = false;
        _button.interactable = false;
    }
}
