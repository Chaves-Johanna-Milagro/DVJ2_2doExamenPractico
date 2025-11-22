using UnityEngine;

public static class StaticAmount
{
    private static float _amount = 0f;
    private static float _maxAmount = 100f;

    private static float _isBotella = 30f;

    private static float _isLata = 20f;
    private static float _isBolsa = 20f;

    private static float _isComida = 10f;
    private static float _isPapel = 10f;

    private static string _botella = "Botella";

    private static string _lata = "Lata";
    private static string _bolsa = "Bolsa";

    private static string _comida = "Comida";
    private static string _papel = "Papel";

    public static bool AmountChanged { get; private set; } = false;
    public static bool IsFull => _amount >= _maxAmount;
    public static bool IsEmpty => _amount <= 0f;

    // SUMA según el tag del objeto
    public static void AddAmountByTag(GameObject obj)
    {
        string tag = obj.tag;

        float old = _amount;

        float addValue = 0f;

        if (tag == _botella)
        {
            addValue = _isBotella;
        }
        else if (tag == _comida)
        {
            addValue = _isComida;
        }
        else if (tag == _papel)
        {
            addValue = _isPapel;
        }
        else if (tag == _lata)
        {
            addValue = _isLata;
        }
        else if (tag == _bolsa)
        {
            addValue = _isBolsa;
        }
        else
        {
            Debug.Log("[StaticAmount] Tag '" + tag + "' no tiene puntaje asociado.");
        }

        // Ajustar para no pasar el máximo
        float spaceLeft = _maxAmount - _amount;
        if (addValue > spaceLeft)
        {
            addValue = spaceLeft;
        }

        _amount += addValue;

        if (_amount != old) AmountChanged = true;
    }

    // RESTA si el tag del objeto NO coincide con el tag correcto
    // Ej: RestaScore(obj, "Botella")   ← si obj.tag NO es "Botella", resta
    // Aqui recibira el tag del objto y el nombre del sprite
    public static void RestAmount(GameObject obj)
    {
        string tag = obj.tag;

        float old = _amount;

        if (tag == _botella)
        {
            _amount -= _isBotella;
        }
        else if (tag == _comida)
        {
            _amount -= _isComida;
        }
        else if (tag == _papel)
        {
            _amount -= _isPapel;
        }
        else if (tag == _lata)
        {
            _amount -= _isLata;
        }
        else if (tag == _bolsa)
        {
            _amount -= _isBolsa;
        }
        else
        {
            Debug.Log("[StaticAmount] Tag '" + tag + "' no tiene puntaje asociado.");
        }
        // No baja de cero
        if (_amount < 0f) _amount = 0f;

        if (_amount != old) AmountChanged = true;
    }

    // Obtener puntaje actual
    public static float GetAmount()
    {
        Debug.Log($"[StaticAmount] Cantidad de amount actual {_amount}");
        return _amount;
    }
    public static float GetMaxAmount()
    {
        Debug.Log($"[StaticAmount] Cantidad de amount total {_maxAmount}");
        return _maxAmount;
    }
    public static void ResetFlag()
    {
        AmountChanged = false;
    }
    public static void ResetAmount()
    {
        _amount = 0;
        AmountChanged = true;
    }
}
