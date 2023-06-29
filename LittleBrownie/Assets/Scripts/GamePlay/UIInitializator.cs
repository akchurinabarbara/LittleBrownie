using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitializator : MonoBehaviour
{
    [SerializeField]
    private List<BaseScreenController> _screens;

    void Start()
    {
        foreach(var screen in _screens)
        {
            screen.Initialise();
        }
    }
}
