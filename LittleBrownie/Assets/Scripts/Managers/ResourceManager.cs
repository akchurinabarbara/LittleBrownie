using CommonTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<CollectionID, CollectionDescription> _collectionDescriptions;
    private Dictionary<InventoryItemID, InventoryItem> _inventoryItemDescriptions;

    public Dictionary<CollectionID, CollectionDescription> CollectionDescriptions { get { return _collectionDescriptions; } }

    public Dictionary<InventoryItemID, InventoryItem> InventoryItemDescriptions { get { return _inventoryItemDescriptions; } }

    private void LoadAll()
    {
        var collectionArray = Resources.LoadAll<CollectionDescription>(StringConstants.CollectionsPath);
        _collectionDescriptions = new Dictionary<CollectionID, CollectionDescription>();

        foreach (var collection in collectionArray)
        {
            _collectionDescriptions[collection.ID] = collection;
        }

        var inventoryItemsArray = Resources.LoadAll<InventoryItem>(StringConstants.InventoryItemsPath);

        _inventoryItemDescriptions = new Dictionary<InventoryItemID, InventoryItem>();

        foreach(var inventoryItem in inventoryItemsArray)
        {
            _inventoryItemDescriptions[inventoryItem.ID] = inventoryItem;
        }
    }

    public ResourceManager()
    {
        LoadAll();
    }
}
