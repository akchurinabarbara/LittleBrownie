using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppContext
{
    private static EnergyManager _energyManager;
    private static MoneyManager _moneyManager;
    private static InventoryManager _inventoryManager;
    private static CollectionManager _collectionManager;
    private static ResourceManager _resourceManager;

    public static EnergyManager EnergyManagare {get { return _energyManager; }}
    public static MoneyManager MoneyManager { get { return _moneyManager;  } }
    public static InventoryManager InventoryManager { get { return _inventoryManager; } }
    public static CollectionManager CollectionManager { get { return _collectionManager; } }
    public static ResourceManager ResourceManager { get { return _resourceManager; } }


    public static void Configure()
    {
        DatabaseHandler _databaseHandler = new DatabaseHandler();

        _energyManager = new EnergyManager(_databaseHandler);
        _moneyManager = new MoneyManager(_databaseHandler);
        _inventoryManager = new InventoryManager(_databaseHandler);
        _collectionManager = new CollectionManager(_databaseHandler);
        _resourceManager = new ResourceManager();
    }

    public static void Save()
    {
        _energyManager.Save();
        _moneyManager.Save();
        _inventoryManager.Save();
        _collectionManager.Save();
    }
}
