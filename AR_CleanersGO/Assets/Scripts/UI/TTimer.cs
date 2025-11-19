using TMPro;
using UnityEngine;

public class TTimer : MonoBehaviour
{
    private float _timeLeft = 60f; // 1 minuto
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

        // Contar hacia atrás
        _timeLeft -= Time.deltaTime;

        // Evitar valores negativos
        if (_timeLeft < 0)
            _timeLeft = 0;

        // Mostrar tiempo en formato MM:SS
        UpdateTimerUI();

        // Cuando llega a 0 → aplicar penalización
        if (_timeLeft == 0 && !_timerEnded)
        {
            _timerEnded = true;
            OnTimerEnd();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(_timeLeft / 60);
        int seconds = Mathf.FloorToInt(_timeLeft % 60);

        _timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimerEnd()
    {
        Debug.Log("⏳ Tiempo terminado. Restando puntos...");

        // Buscar toda la basura que sigue en la escena
        TrashScore[] allTrash = FindObjectsOfType<TrashScore>();

        foreach (TrashScore trash in allTrash)
        {
            int points = trash.GetScore();

            // Restar puntaje por basura no recogida
            StaticScoreTrash.SubtractScore(points);

            // Opcional: limpiar la escena
            // trash.gameObject.SetActive(false);
            // Destroy(trash.gameObject);
        }

        Debug.Log("Puntaje final después de penalización: " + StaticScoreTrash.GetScore());
    }
}
