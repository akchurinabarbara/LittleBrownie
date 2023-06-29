using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenController : BaseScreenController
{
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _okButton;
    [SerializeField]
    private Transform _itemCardParent;
    [SerializeField]
    private GameObject _itemCard;


    private List<ItemCardController> _itemCardList = new List<ItemCardController>();

    public override void Initialise()
    {
        base.Initialise();

        for (int i = _itemCardList.Count; i < AppContext.InventoryManager.Inventory.Count; i++)
        {
            _itemCardList.Add(Instantiate(_itemCard, _itemCardParent).GetComponent<ItemCardController>());
        }
    }

    public override void SetInformation()
    {
        base.SetInformation();

        int i = 0;

        foreach(var item in AppContext.InventoryManager.Inventory)
        {
            if (item.Value > 0)
            {
                Sprite icon = AppContext.ResourceManager.InventoryItemDescriptions[item.Key].Icon;
                _itemCardList[i].SetInformation(icon, item.Value, true);
                _itemCardList[i].gameObject.SetActive(true);               
            }
            else
            {
                _itemCardList[i].gameObject.SetActive(false);
            }

            i++;
        }
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