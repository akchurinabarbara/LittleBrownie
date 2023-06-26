using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppContext
{
    private static EnergyManager _energyManager;
    private static MoneyManager _moneyManager;
    private static InventoryManager _inventoryManager;
    private static CollectionManager _collectionManager;

    public static EnergyManager EnergyManagare {get { return _energyManager; }}
    public static MoneyManager MoneyManager { get { return _moneyManager;  } }
    public static InventoryManager InventoryManager { get { return _inventoryManager; } }
    public static CollectionManager CollectionManager { get { return _collectionManager; } }


    public static void Configure()
    {
        _energyManager = new EnergyManager();
        _moneyManager = new MoneyManager();
        _inventoryManager = new InventoryManager();
        _collectionManager = new CollectionManager();
    }
}
