using TMPro;
using UnityEngine;

public class TTimer : MonoBehaviour
{
    private TMP_Text _timerText;

    void Start()
    {
        _timerText = GetComponent<TMP_Text>();
        UpdateText(); // Mostrar valor inicial
    }

    void Update()
    {
        if (StaticTimer.IsFinished)
        {
            Debug.Log("[TTimer] Tiempo acabado...");
            return;
        }

        // Restar tiempo cada frame
        StaticTimer.Subtract(Time.deltaTime);

        // Actualizar el texto
        UpdateText();
    }

    private void UpdateText()
    {

        float time = StaticTimer.GetTime();

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        // Formato MM:SS
        _timerText.text = $"{minutes:00}:{seconds:00}";
    }

}
