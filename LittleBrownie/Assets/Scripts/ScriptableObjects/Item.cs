using CommonTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ���������� ������� ��������
[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public ItemType Type;
    public Sprite Icon;
}
