using UnityEngine;
using TMPro;

public class TStatistic : MonoBehaviour
{
    private TMP_Text _text;

    void Start()
    {
        _text = GetComponent<TMP_Text>();

        Statistics();
    }

    private void Statistics()
    {
        string score = StaticScore.GetScore().ToString();

        string reciclado = StaticStatistics.GetReciclados().ToString();
        string recolectado = StaticStatistics.GetRecolectados().ToString();

        _text.text =
                     $"Puntaje final:     {score}\n" +
                     "\n" +
                     $"Basura \nrecolectada:     {recolectado}\n" +
                     "\n" +
                     $"Basura \nReciclada:     {reciclado}";
    }
}
