using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenController : BaseScreenController
{
    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private Button _okButton;

    public override void SetInformation()
    {
        base.SetInformation();
    }

    private void OnExitButtonClick()
    {
        ShowNext(0);
    }

    private void OnOkButtonClick()
    {
        ShowNext(0);
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _okButton.onClick.AddListener(OnOkButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _okButton.onClick.RemoveListener(OnOkButtonClick);
    }
}