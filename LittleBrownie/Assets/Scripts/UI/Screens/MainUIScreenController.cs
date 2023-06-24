using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScreenController : BaseScreenController
{
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