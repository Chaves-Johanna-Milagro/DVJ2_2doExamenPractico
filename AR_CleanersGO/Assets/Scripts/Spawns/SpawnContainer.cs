using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnContainer : MonoBehaviour
{
    private ARPlaneManager _planeManager;
    private GameObject[] _prefabs;

    private int maxObjs = 8;         
    private float spawnInterval = 2.5f; 

    private int currentIndex = 0;

    void Start()
    {
        _planeManager = GetComponent<ARPlaneManager>();

        // Cargar prefabs desde Resources/Container/
        _prefabs = Resources.LoadAll<GameObject>("Container");

        // Comienza la corrutina de instanciado
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (currentIndex < _prefabs.Length && currentIndex < maxObjs)
        {
            yield return new WaitForSeconds(spawnInterval);

            ARPlane biggestPlane = GetBiggestPlane();
            if (biggestPlane != null)
            {
                SpawnOnPlane(biggestPlane);
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

    private void SpawnOnPlane(ARPlane plane)
    {
        if (plane.boundary.Length < 3) return;

        // Elegir un punto random dentro del bounding box del plano
        Vector2 randomPoint = Random.insideUnitCircle;

        // Convertirlo al área del plano real
        Vector3 pos = plane.center + new Vector3(
            randomPoint.x * plane.size.x * 0.5f,
            0,
            randomPoint.y * plane.size.y * 0.5f
        );
        pos.y += 0.5f; // elevar un toke

        Instantiate(_prefabs[currentIndex], pos, Quaternion.identity);
        currentIndex++;
    }

}
