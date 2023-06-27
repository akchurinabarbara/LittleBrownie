using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CollectionManager 
{
    private Dictionary<CollectionItemID, int> _collection;

    private Dictionary<ItemType, Action<Enum, int>> _addReward = new Dictionary<ItemType, Action<Enum, int>>
    {
        [ItemType.money] = (Enum id, int count) => { AppContext.MoneyManager.Add(count); },
        [ItemType.inventoryItem] = (Enum id, int count) => { AppContext.InventoryManager.Inventory[(InventoryItemID)id] += count; },
    };

    public Dictionary<CollectionItemID, int> Collection
    {
        get { return _collection; }

        private set
        {
            _collection = value;
        }
    }

    public CollectionManager()
    {
        _collection = new Dictionary<CollectionItemID, int>();

        foreach (CollectionItemID collectionItemID in Enum.GetValues(typeof(CollectionItemID)))
        {
            _collection[collectionItemID] = 0;
        }
    }

    //TODO ��������� ��� ��������� ������� ����, ����� ����� �������
    public bool CheckAll(ItemWithID<CollectionItemID>[] items)
    {
        bool result = true;
        foreach(var item in items)
        {
            if (_collection[item.ID] <= 0)
            { 
                result = false;
                break;
            }

        }

        return result;
    }

    public void GetReward(CollectionID id)
    {
        var collection = AppContext.ResourceManager.CollectionDescriptions[id];

        if (CheckAll(collection.Items))
        {
            foreach(var item in collection.Items)
            {
                _collection[item.ID]--;
            }

            FieldInfo fi = collection.reward.GetType().GetField("ID");
            Enum rewardID = (Enum)fi?.GetValue(collection.reward);

            if (rewardID != null)
            {
                _addReward[collection.reward.Type]?.Invoke(id, collection.count);
            }
        }
    }
}
