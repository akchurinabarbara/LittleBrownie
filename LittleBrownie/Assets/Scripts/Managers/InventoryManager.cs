using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager 
{
    private const int _startValue = 0;

    private Dictionary<InventoryItemID, int> _inventory;
    private DatabaseHandler _databaseHandler;

    public Dictionary<InventoryItemID, int> Inventory 
    { 
        get { return _inventory; }
        
        private set
        {
            _inventory = value;
        }
    }

    public InventoryManager(DatabaseHandler databaseHandler)
    {
        _inventory = new Dictionary<InventoryItemID, int>();

        _databaseHandler = databaseHandler;

        var inventoryFromDB = _databaseHandler.GetInventory();

        if (inventoryFromDB.Count == 0)
        {            
            foreach (InventoryItemID inventoryItemID in Enum.GetValues(typeof(InventoryItemID)))
            {
                _inventory[inventoryItemID] = _startValue;
                _databaseHandler.AddInventory(inventoryItemID, _startValue);
            }
        }

        else
        {
            foreach(var inventoryItem in inventoryFromDB)
            {
                _inventory[(InventoryItemID)inventoryItem.InventoryItemID] = inventoryItem.Count;
            }
        }
    }

    public void Add(InventoryItemID id, int addValue)
    {
        _inventory[id] += addValue;
    }


    public void Spend(InventoryItemID id, int spendValue)
    {
        _inventory[id] -= spendValue;
    }


    public void Save()
    {
        foreach (var inventory in _inventory)
        {
            _databaseHandler.UpdateInventory(inventory.Key, inventory.Value);
        }
    }
}
