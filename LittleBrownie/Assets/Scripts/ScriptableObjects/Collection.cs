using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Дескриптор коллекций
[CreateAssetMenu(fileName = "collection", menuName = "ScriptableObjects/Collection", order = 1)]
public class Collection : ScriptableObject
{
    public CollectionID ID;

    public ItemWithID<CollectionItemID>[] Items = new ItemWithID<CollectionItemID>[5];

    public Item reward;
    public int count;
}
