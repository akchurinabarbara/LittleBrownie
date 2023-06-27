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

    private List<CollectionPanelController> _collectionPanelList = new List<CollectionPanelController>();

    public override void Initialise()
    {
        base.Initialise();

        foreach (var colection in AppContext.ResourceManager.CollectionDescriptions)
        {
            var collectionPanel = Instantiate(_collectionPanel, _collectionsPanelParent).GetComponent<CollectionPanelController>();

            collectionPanel.OnGetReward += SetInformation;

            _collectionPanelList.Add(collectionPanel);
        }
    }

    public override void SetInformation()
    {
        base.SetInformation();

        var collections = AppContext.ResourceManager.CollectionDescriptions;

        int i = 0;
        foreach (var collection in collections)
        {
            _collectionPanelList[i].SetInformation(collection.Value);
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