using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Дескриптор коллекций
[CreateAssetMenu(fileName = "collection", menuName = "ScriptableObjects/Collection", order = 1)]
public class CollectionDescription : ScriptableObject
{
    public CollectionID ID;

    public ItemWithIDDescription<CollectionItemID>[] Items = new ItemWithIDDescription<CollectionItemID>[5];

    public ItemDescription reward;
    public int count;
}
