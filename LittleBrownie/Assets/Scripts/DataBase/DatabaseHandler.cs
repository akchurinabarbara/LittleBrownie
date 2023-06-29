using CommonTypes;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseHandler
{
    private SQLiteConnection _db;

    public DatabaseHandler()
    {
        _db = new SQLiteConnection(Application.dataPath + "/StreamingAssets/db.bytes");
        _db.CreateTable<Energy>();
        _db.CreateTable<Money>();
        _db.CreateTable<Inventory>();
        _db.CreateTable<Collection>();
    }

    public void AddEnergy(int value)
    {
        var energy = new Energy { count = value };

        _db.Insert(energy);
    }

    public List<Energy> GetEnergy()
    {
        return _db.Query<Energy>("Select * from Energy");
    }

    public void UpdateEnergy(int value)
    {
        var energy = new Energy { count = value };

        _db.Update(energy);
    }

    public void AddMoney(MoneyItemID id, int count)
    {
        var money = new Money
        {
            CollectionItemID = (int)id,
            Count = count
        };

        _db.Insert(money);
    }

    public List<Money> GetMoney()
    {
        return _db.Query<Money>("Select * from Money");
    }

    public void UpdateMoney(MoneyItemID id, int count)
    {
        var money = new Money
        {
            CollectionItemID = (int)id,
            Count = count
        };

        _db.Update(money );
    }

    public void AddInventory(InventoryItemID id, int count)
    {
        var inventory = new Inventory
        {
            InventoryItemID = (int)id,
            Count = count
        };

        _db.Insert(inventory);
    }

    public List<Inventory> GetInventory()
    {
        return _db.Query<Inventory>("Select * from Inventory");
    }

    public void UpdateInventory(InventoryItemID id, int count)
    {
        var inventory = new Inventory
        {
            InventoryItemID = (int)id,
            Count = count
        };

        _db.Update(inventory);
    }

    public void AddCollection(CollectionItemID id, int count)
    {
        var collection = new Collection
        {
            CollectionItemID = (int)id,
            Count = count
        };

        _db.Insert(collection);
    }

    public List<Collection> GetCollection()
    {
        return _db.Query<Collection>("Select * from Collection");
    }

    public void UpdateCollection(CollectionItemID id, int count)
    {
        var collection = new Collection
        {
            CollectionItemID = (int)id,
            Count = count
        };

        _db.Update(collection);
    }
}

