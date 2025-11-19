using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnRandomContainer : MonoBehaviour
{
    private ARPlaneManager _planeManager;

    private GameObject[] _prefabs;

    private const int _maxObjs = 8;
    private int _spawnedObjs = 0;

    private float _spawnInterval = 5f;

    void Start()
    {
        _planeManager = GetComponent<ARPlaneManager>();

        // Cargar prefabs desde Resources/MisObjetos/
        _prefabs = Resources.LoadAll<GameObject>("ContainerObjs");

        // Comienza la rutina de instanciado
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (_spawnedObjs < _maxObjs)
        {
            yield return new WaitForSeconds(_spawnInterval);

            ARPlane biggestPlane = GetBiggestPlane();

            if (biggestPlane != null)
            {
                SpawnRandomOnPlane(biggestPlane);
            }
        }
    }


    private ARPlane GetBiggestPlane()
    {
        ARPlane biggest = null;
        float largestArea = 0f;

        foreach (var plane in _planeManager.trackables)
        {
            float area = plane.size.x * plane.size.y;

            if (area > largestArea)
            {
                largestArea = area;
                biggest = plane;
            }
        }

        return biggest;
    }


    private void SpawnRandomOnPlane(ARPlane plane)
    {
        if (plane.boundary.Length < 3) return; // No está bien formado todavía

        // Elegir un punto random dentro del bounding box del plano
        Vector2 randomPoint = Random.insideUnitCircle;

        // Convertirlo al área del plano real
        Vector3 pos = plane.center + new Vector3(
            randomPoint.x * plane.size.x * 0.5f,
            0,
            randomPoint.y * plane.size.y * 0.5f
        );

        pos.y += 1f; // elevar un toque

        // Elegir prefab random
        GameObject prefab = _prefabs[Random.Range(0, _prefabs.Length)];

        Instantiate(prefab, pos, Quaternion.identity);

        _spawnedObjs++;
    }
}
