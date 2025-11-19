using UnityEngine;
using TMPro;

public class TScore : MonoBehaviour
{
    private CameraRayPoint _camRay;

    private TMP_Text _text;

    private int _lastScore = -1;

    void Start()
    {
        _camRay = FindObjectOfType<CameraRayPoint>();

        _text = GetComponent<TMP_Text>();

        UpdateScoreText(StaticScoreTrash.GetScore());
    }

    void Update()
    {
        int currentScore = StaticScoreTrash.GetScore();

        // Solo actualiza si el score cambió
        if (currentScore != _lastScore)
        {
            UpdateScoreText(currentScore);
        }
    }

    private void UpdateScoreText(int newScore)
    {
        _lastScore = newScore;
        _text.text = newScore.ToString();
    }
}
