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

    private Sprite _default; // Pa cuando se le acabe la basura vuelva al blanco
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

        _default = _image.sprite;
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


        ContainerAmount cAmount = obj.GetComponent<ContainerAmount>();

        if (cAmount != null)
        {
            float restar = cAmount.GetAmount();
            StaticAmountTrash.SubtractAmount(restar);

            Debug.Log("Restando → " + restar + " | Nuevo amount: " + StaticAmountTrash.GetAmount());
        }


        bool basuraCorrecta = false;

        // Comparaacion de sprites 
        ContainerSprite container = obj.GetComponent<ContainerSprite>();

        if (container != null)
        {
            Sprite containerSprite = container.GetSprite();
            Sprite dropSprite = _image.sprite; 

            if ( dropSprite == containerSprite)
            {
                basuraCorrecta = true;
                Debug.Log("✔ Basura correcta");
            }
            else
            {
                basuraCorrecta = false;
                Debug.Log("✘ Basura incorrecta");
            }
        }


        ContainerScore cScore = obj.GetComponent<ContainerScore>();

        if (cScore != null)
        {
            int score = cScore.GetScore();

            if (basuraCorrecta)
            {
                StaticScoreTrash.AddScore(score);
                Debug.Log("SUMANDO score: +" + score + " → Total: " + StaticScoreTrash.GetScore());
            }
            else
            {
                StaticScoreTrash.SubtractScore(score);
                Debug.Log("RESTANDO score: -" + score + " → Total: " + StaticScoreTrash.GetScore());
            }
        }


        _sprites = StaticSpriteTrash.GetSprites();

        if (_sprites.Count == 0)
            return;

        _currentSpriteIndex++;

        if (_currentSpriteIndex >= _sprites.Count)
        {
            _image.sprite = _default;
            return;
        }
            //_currentSpriteIndex = 0;

        _image.sprite = _sprites[_currentSpriteIndex];

        Debug.Log("Sprite cambiado → " + _image.sprite.name);
    }
}
