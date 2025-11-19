using UnityEngine;

public static class StaticScoreTrash
{
    private static int _score = 0;

    public static void AddScore(int newScore)
    {
        _score += newScore;
    }
    public static void SubtractScore(int newScore)
    {
        _score -= newScore;
    }

    public static int GetScore()
    {
        return _score;
    }
}

