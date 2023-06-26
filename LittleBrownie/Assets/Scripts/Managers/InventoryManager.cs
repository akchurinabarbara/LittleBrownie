using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager 
{
    private Dictionary<InventoryItemID, int> _inventory;

    public Dictionary<InventoryItemID, int> Inventory 
    { 
        get { return _inventory; }
        
        private set
        {
            _inventory = value;
        }
    }

    public InventoryManager()
    {
        //TODO чтение данных из SQLLite
        _inventory = new Dictionary<InventoryItemID, int>();

        foreach (InventoryItemID inventoryItemID in Enum.GetValues(typeof(InventoryItemID)))
        {
            _inventory[inventoryItemID] = 0;
        }
    }
}
