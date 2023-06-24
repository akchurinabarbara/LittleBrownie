using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    [Header("UI View")]
    [SerializeField]
    private TextMeshProUGUI _energyText;

    [Header("Start Count")]
    [SerializeField]
    private int _startCount;

    [Header("Timer")]
    [SerializeField]
    private float _generateDelay;
    [SerializeField]
    private int _generateCount;

    private int _currentEnergy; 

    public int CurrentEnergy
    {
        get { return _currentEnergy; }

        private set
        {
            _currentEnergy = value;
            _energyText.text = value.ToString();
        }
    }

    public bool CheckEnergy()
    {
        return CurrentEnergy > 0;
    }

    public void SpendEnergy()
    {
        CurrentEnergy--;
    }

    private IEnumerator GenerateTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_generateDelay);

            for (int i = 0; i < _generateCount; i++)
            {
                CurrentEnergy+= _generateCount;
            }
        }
    }

    private void Start()
    {
        CurrentEnergy = _startCount;

        StartCoroutine(GenerateTimer());
    }
}
