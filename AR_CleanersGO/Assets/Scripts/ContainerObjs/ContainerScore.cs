using UnityEngine;

public class ContainerScore : MonoBehaviour
{
    private int _score;

    void Start()
    {
        string name = gameObject.name;

        if (name == "Cube(Clone)")
        {
            _score = 30;

        }
        if (name == "Sphere(Clone)")
        {
            _score = 10;

        }
        if (name == "Capsule(Clone)")
        {
            _score = 20;

        }

    }

    public int GetScore()
    {
        return _score;
    }
}
