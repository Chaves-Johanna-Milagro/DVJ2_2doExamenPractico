using UnityEngine;

public class ContainerAmount : MonoBehaviour
{
    private float _amount;

    void Start()
    {
        string name = gameObject.name;

        if (name == "Cube(Clone)")
        {
            _amount = 10f;

        }
        if (name == "Sphere(Clone)")
        {
            _amount = 20f;

        }
        if (name == "Capsule(Clone)")
        {
            _amount = 30f;

        }

    }

    public float GetAmount()
    {
        return _amount;
    }
}
