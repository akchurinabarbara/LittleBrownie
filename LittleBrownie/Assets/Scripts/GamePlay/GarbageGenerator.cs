using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGenerator : MonoBehaviour
{
    [Header("Start Count")]
    [SerializeField]
    private int _maxStartCount;
    [SerializeField]
    private int _minStartCount;

    [Header("Timer")]
    [SerializeField]
    private float _generateDelay;
    [SerializeField]
    private int _generateCount;

    [Header("Position")]
    [SerializeField]
    private float _maxX;
    [SerializeField]
    private float _minX;

    [Header("Garbage")]
    [SerializeField]
    private List<GameObject> _garbagePrefabs = null;

    Coroutine _generateCoroutine;

    private void GenerateGarbage()
    {
        int garbageIndex = Random.Range(0, _garbagePrefabs.Count);

        Vector3 garbagePosition = new Vector3(Random.Range(_minX, _maxX), transform.position.y, transform.position.z);

        GameObject newGarbage = Instantiate(_garbagePrefabs[garbageIndex], garbagePosition, Quaternion.identity, transform);
    }

    private IEnumerable GenerateTimer()
    {
        yield return new WaitForSeconds(_generateDelay);

        for (int i = 0; i < _generateCount; i++)
        {
            GenerateGarbage();
        }
    }

    private void Awake()
    {
        int StartCount = Random.Range(_minStartCount, _maxStartCount);

        for (int i = 0; i < StartCount; i++)
        {
            GenerateGarbage();
        }

        _generateCoroutine = StartCoroutine("GenerateTimer");
    }
}
