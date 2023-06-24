using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagesContoller : MonoBehaviour
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

    [Header("Broom")]
    [SerializeField]
    private GameObject _broom;
    [SerializeField]
    private Vector3 _broomOffset;

    [Header("Garbage")]
    [SerializeField]
    private List<GameObject> _garbagePrefabs = null;

    private Garbage _selectedGarbage;

    private List<Garbage> _garbageList = new List<Garbage>();

    private Coroutine _generateCoroutine;

    private void OnRemoveGarbage(Garbage removeGarbage)
    {      

        Broom newBroom = Instantiate(_broom, removeGarbage.transform.position + _broomOffset, Quaternion.identity, transform).GetComponent<Broom>();
        newBroom.SweepTime = removeGarbage.RemoveTime;
        _garbageList.Remove(removeGarbage);
    }

    private void OnClickGarbage(Garbage newSelectedGarbage)
    {
        _selectedGarbage?.ResetSelection();
        _selectedGarbage = newSelectedGarbage;
    }

    private void GenerateGarbage()
    {
        int garbageIndex = Random.Range(0, _garbagePrefabs.Count);

        Vector3 garbagePosition = new Vector3(Random.Range(_minX, _maxX), transform.position.y, transform.position.z);

        Garbage newGarbage = Instantiate(_garbagePrefabs[garbageIndex], garbagePosition, Quaternion.identity, transform).GetComponent<Garbage>();

        newGarbage.OnClick += OnClickGarbage;
        newGarbage.OnRemove += OnRemoveGarbage;

        _garbageList.Add(newGarbage);
    }

    private IEnumerator GenerateTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_generateDelay);

            for (int i = 0; i < _generateCount; i++)
            {
                GenerateGarbage();
            }
        }
    }

    private void Awake()
    {
        int StartCount = Random.Range(_minStartCount, _maxStartCount);

        for (int i = 0; i < StartCount; i++)
        {
            GenerateGarbage();
        }

        _generateCoroutine = StartCoroutine(GenerateTimer());
    }

    private void Update()
    {
        if (_selectedGarbage && Input.GetMouseButtonDown(0))
        {
            _selectedGarbage.ResetSelection();
            _selectedGarbage = null;
        }
    }
}
