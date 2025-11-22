using UnityEngine;

public static class StaticScore
{
    private static int _score = 0;

    private static int _isBotella = 30;

    private static int _isLata = 20;
    private static int _isBolsa = 20;

    private static int _isComida = 10;
    private static int _isPapel = 10;

    private static string _botella = "Botella";

    private static string _lata = "Lata";
    private static string _bolsa = "Bolsa";

    private static string _comida = "Comida";
    private static string _papel = "Papel";

    public static bool ScoreChanged { get; private set; } = false;

    // SUMA según el tag del objeto
    public static void AddScoreByTag(GameObject obj)
    {
        string tag = obj.tag;

        int oldScore = _score;

        if (tag == _botella)
        {
            _score += _isBotella;
        }
        else if (tag == _comida)
        {
            _score += _isComida;
        }
        else if (tag == _papel)
        {
            _score += _isPapel;
        }
        else if (tag == _lata)
        {
            _score += _isLata;
        }
        else if (tag == _bolsa)
        {
            _score += _isBolsa;
        }
        else
        {
            Debug.Log("[StaticScore] Tag '" + tag + "' no tiene puntaje asociado.");
        }

        if (_score != oldScore) ScoreChanged = true;
    }

    // RESTA si el tag del objeto NO coincide con el tag correcto
    // Ej: RestaScore(obj, "Botella")   ← si obj.tag NO es "Botella", resta
    public static void RestaScore(GameObject obj, string tagCorrecto)
    {
        string tag = obj.tag;

        if (tag != tagCorrecto)
        {
            // Podés definir cuánto resta: uso el mismo valor que sumaría
            if (tagCorrecto == _botella)
            {
                _score -= _isBotella;
            }
            else if (tagCorrecto == _comida)
            {
                _score -= _isComida;
            }
            else if (tagCorrecto == _papel)
            {
                _score -= _isPapel;
            }
            else if (tagCorrecto == _lata)
            {
                _score -= _isLata;
            }
            else if (tagCorrecto == _bolsa)
            {
                _score -= _isBolsa;
            }
            else
            {
                Debug.Log("[StaticScore] Tag correcto '" + tagCorrecto + "' no está configurado.");
            }
        }
    }

    // Obtener puntaje actual
    public static int GetScore()
    {
        Debug.Log($"[StaticScore] Cantidad de puntaje actual {_score}");
        return _score;
    }

    public static void ResetFlag()
    {
        ScoreChanged = false;
    }
}
