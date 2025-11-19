using TMPro;
using UnityEngine;

public class TTimer : MonoBehaviour
{
    private TMP_Text _timerText;

    private bool _timerEnded = false;

    void Start()
    {
        _timerText = GetComponent<TMP_Text>();
    }


    void Update()
    {
        if (_timerEnded)
            return;

        // restamos tiempo usando la statica
        StaticTimer.Subtract(Time.deltaTime);

        // actualizar UI
        UpdateTimerUI();

        // si llegó a cero → ejecutar penalización una sola vez
        if (StaticTimer.IsFinished && !_timerEnded)
        {
            _timerEnded = true;
            ApplyFinalPenalty();
        }
    }

    private void UpdateTimerUI()
    {
        float t = StaticTimer.GetTime();

        int minutes = Mathf.FloorToInt(t / 60);
        int seconds = Mathf.FloorToInt(t % 60);

        _timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void ApplyFinalPenalty()
    {
        Debug.Log("Tiempo agotado...");

        // Penalización por basura no recogida
        TrashScore[] allTrash = FindObjectsOfType<TrashScore>();

        foreach (TrashScore trash in allTrash)
        {
            int points = trash.GetScore();
            StaticScoreTrash.SubtractScore(points);

            Debug.Log($"Restando {points} por basura no recogida ({trash.name})");
        }


        // Penalizar por amount restante
        float amountLeft = StaticAmountTrash.GetAmount();

        if (amountLeft > 0)
        {
            int penalty = Mathf.FloorToInt(amountLeft);
            StaticScoreTrash.SubtractScore(penalty);

            StaticAmountTrash.SubtractAmount(penalty);

            Debug.Log($"Restando {penalty} puntos por amount restante");
        }

        Debug.Log("Puntaje final: " + StaticScoreTrash.GetScore());
    }
}
