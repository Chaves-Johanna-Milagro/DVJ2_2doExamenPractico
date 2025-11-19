using UnityEngine;

public static class StaticAmountTrash
{
    private static float _amount = 0;
    private static float _maxAmount = 200f; // Equivaldria al total de la imagen completa de la barrita

    public static bool IsFull => _amount >= _maxAmount;

    public static void AddAmount(float newAmount)
    {
        if (IsFull)
            return; // ya está lleno, no sumar

        _amount += newAmount;

        // evitar pasar el límite
        if (_amount >= _maxAmount)
            _amount = _maxAmount;
    }

    public static void SubtractAmount(float newAmount)
    {
        _amount -= newAmount;

        if (_amount < 0)
            _amount = 0;
    }

    public static float GetAmount() => _amount;

    public static float GetMaxAmount() => _maxAmount;
}
