using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���������� ���� ��������� � ����������� ID
[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemWithID<T>  : Item where T : Enum
{
    public T ID;
}
