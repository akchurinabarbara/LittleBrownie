using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScreenController : BaseScreenController
{
    [SerializeField]
    private TextMeshProUGUI _energyText;
    [SerializeField]
    private TextMeshProUGUI _moneyText;
    [SerializeField]
    private Button _collectionButton = null;
    [SerializeField]
    private Button _inventoryButton = null;
     
    public override void SetInformation()
    {
        base.SetInformation();
    }

    private void OnCollectionButtonClick()
    {
        ShowNext(0);
    }

    private void OnInventotyButtonClick()
    {
        ShowNext(1);
    }

    private void OnEnergyValueChange(int value)
    {
        _energyText.text = value.ToString();
    }

    private void OnMoneyValueChange(int value)
    {
        _moneyText.text = value.ToString();
    }

    private void Awake()
    {
        OnEnergyValueChange(AppContext.EnergyManagare.CurrentValue);
        AppContext.EnergyManagare.OnValueChange += OnEnergyValueChange;

        OnMoneyValueChange(AppContext.MoneyManager.CurrentValue);
        AppContext.MoneyManager.OnValueChange += OnMoneyValueChange;
    }

    private void OnEnable()
    {
        _collectionButton.onClick.AddListener(OnCollectionButtonClick);
        _inventoryButton.onClick.AddListener(OnInventotyButtonClick);
    }

    private void OnDisable()
    {
        _collectionButton.onClick.RemoveListener(OnCollectionButtonClick);
        _inventoryButton.onClick.RemoveListener(OnInventotyButtonClick);
    }
}