using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyGenerator : MonoBehaviour
{
    [SerializeField]
    private float _generateDelay;
    [SerializeField]
    private int _generateCount;        

    private IEnumerator GenerateTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_generateDelay);

            for (int i = 0; i < _generateCount; i++)
            {
                AppContext.EnergyManagare.Add(_generateCount);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(GenerateTimer());
    }
}
