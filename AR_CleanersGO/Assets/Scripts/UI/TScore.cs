using UnityEngine;
using TMPro;

public class TScore : MonoBehaviour
{
    private TMP_Text _text;

    void Start()
    {
        _text = GetComponent<TMP_Text>();

        _text.text = StaticScore.GetScore().ToString();

    }

    void Update()
    {
        if (StaticScore.ScoreChanged)
        {
            _text.text = StaticScore.GetScore().ToString();
            StaticScore.ResetFlag();
        }
    }
}
