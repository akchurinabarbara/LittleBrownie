using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreenController : MonoBehaviour
{
    [SerializeField]
    protected List<BaseScreenController> _nextScreens;

    public virtual void Initialise() { }
    public virtual void SetInformation() { }

    public void ShowNext(int i)
    {
        Hide();
        _nextScreens[i].Show();
    }

    public void Show()
    {
        SetInformation();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}