using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardController : MonoBehaviour
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TextMeshProUGUI _countText;
    [SerializeField]
    private Color _enableColor;
    [SerializeField]
    private Color _disableColor;

    public void SetInformation(Sprite icon, int count, bool enable)
    {
        _icon.sprite = icon;
        _icon.color = enable ? _enableColor : _disableColor;

        _countText.text = count.ToString();
    }
}
