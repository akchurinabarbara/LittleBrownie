using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPanelController : MonoBehaviour
{
    [SerializeField]
    List<ItemCardController> _itemCardList = null;
    [SerializeField]
    private Image _rewardIcon;
    [SerializeField]
    private TextMeshProUGUI _rewardCountText;
    [SerializeField]
    private Button _getRewardButton;

    private CollectionID _currentCollectionID;
   
    public Action OnGetReward;

    private void OnGetRewardClick()
    {
        AppContext.CollectionManager.GetReward(_currentCollectionID);
        OnGetReward?.Invoke();
    }

    public void SetInformation(CollectionDescription collection)
    {
        _currentCollectionID = collection.ID;

        for (int i = 0; i < collection.Items.Length; i++)
        {
            int count = AppContext.CollectionManager.Collection[collection.Items[i].ID];
            _itemCardList[i].SetInformation(collection.Items[i].Icon, count, count > 0);
        }

        _rewardIcon.sprite = collection.reward.Icon;
        _rewardCountText.text = collection.count.ToString();


        _getRewardButton.interactable = AppContext.CollectionManager.CheckAll(collection.Items);
    }

    private void OnEnable()
    {
        _getRewardButton.onClick.AddListener(OnGetRewardClick);
    }

    private void OnDisable()
    {
        _getRewardButton.onClick.RemoveListener(OnGetRewardClick);
    }
}
