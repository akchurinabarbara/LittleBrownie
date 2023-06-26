using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionsScreenController : BaseScreenController
{
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _okButton;
    [SerializeField]
    private Transform _collectionsPanelParent;
    [SerializeField]
    private GameObject _collectionPanel;

    [SerializeField]
    private List<Collection> _collectionList;

    private List<CollectionPanelController> _collectionPanelList = new List<CollectionPanelController>();

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

    private void Awake()
    {
        foreach(var colection in _collectionList)
        {
            var collectionPanel = Instantiate(_collectionPanel, _collectionsPanelParent).GetComponent<CollectionPanelController>();


            _collectionPanelList.Add(collectionPanel);
        }
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