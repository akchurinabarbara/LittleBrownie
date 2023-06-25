using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppContext
{
    private static EnergyManager _energyManager;
    private static MoneyManager _moneyManager;

    public static EnergyManager EnergyManagare {get { return _energyManager; }}
    public static MoneyManager MoneyManager { get { return _moneyManager;  } }

    public static void Configure()
    {
        _energyManager = new EnergyManager();
        _moneyManager = new MoneyManager();
    }
}
