using UnityEngine;

// Pa almacenar los datos y puntajes al acabarce el tiempo
public static class StaticStatistics
{
    private static int _cantReciclados = 0;
    private static int _cantRecolectados = 0;

    // Pa cuando se recicle correctamente
    public static void Reciclado()
    {
        _cantReciclados++;
    }

    public static int GetReciclados()
    {
        return _cantReciclados;
    }

    // Pa cuando se recolecte basura
    public static void Recolectado()
    {
        _cantRecolectados++;
    }

    public static int GetRecolectados()
    {
        return _cantRecolectados;
    }

}
