using UnityEngine;

public static class StaticTimer
{
    private static float _time = 120f; // 2 minutos

    public static void SetTime(float newTime)
    {
        _time = newTime;
    }

    public static void Subtract(float delta)
    {
        _time -= delta;
        if (_time < 0) _time = 0;
    }

    public static bool IsFinished => _time <= 0f;
    public static float GetTime() => _time;
  
}
