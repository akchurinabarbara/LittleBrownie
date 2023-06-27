using CommonTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<CollectionID, Collection> _collectionDescriptions;
    private Dictionary<InventoryItemID, InventoryItem> _inventoryItemDescriptions;

    public Dictionary<CollectionID, Collection> CollectionDescriptions { get { return _collectionDescriptions; } }

    public Dictionary<InventoryItemID, InventoryItem> InventoryItemDescriptions { get { return _inventoryItemDescriptions; } }

    private void LoadAll()
    {
        var collectionArray = Resources.LoadAll<Collection>(StringConstants.CollectionsPath);
        _collectionDescriptions = new Dictionary<CollectionID, Collection>();

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
