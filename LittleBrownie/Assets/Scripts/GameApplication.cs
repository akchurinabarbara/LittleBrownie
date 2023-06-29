using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplication : MonoBehaviour
{
    void Awake()
    {
        AppContext.Configure();
    }

    private void OnDisable()
    {
        AppContext.Save();
    }
}
