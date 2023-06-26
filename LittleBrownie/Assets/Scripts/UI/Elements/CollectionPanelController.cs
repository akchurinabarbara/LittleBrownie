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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
