using CommonTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Базовый дескриптов игровых преметов
[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public ItemType Type;
    public Sprite Icon;
}
