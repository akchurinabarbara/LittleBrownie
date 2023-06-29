using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//��������� �������
public class RewardGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _rewardObject;

    [SerializeField]
    private List<ItemDescription> _rewardList = null;

    [SerializeField]
    private Transform _mainUITransform;

    [SerializeField]
    private List<Transform> _endPoints;


    private Dictionary<ItemType, Action<Enum>> _addReward = new Dictionary<ItemType, Action<Enum>>
    {
        [ItemType.money] = (Enum id) => { AppContext.MoneyManager.Add(1); },
        [ItemType.inventoryItem] = (Enum id) => { AppContext.InventoryManager.Inventory[(InventoryItemID) id] += 1; },
        [ItemType.collectionItem] = (Enum id) => { AppContext.CollectionManager.Collection[(CollectionItemID)id] += 1; }
    };

    private IEnumerator GenerateReward(float generateDelay, Vector3 startPosition)
    {
        yield return new WaitForSeconds(generateDelay);


        //�������� ���������� �������
        int i = UnityEngine.Random.Range(0, _rewardList.Count);

        Reward reward = Instantiate(_rewardObject, _mainUITransform).GetComponent<Reward>();

        //���������� �������� ����� � ID �������� �� ����
        Vector3 endPosition = _endPoints[(int)_rewardList[i].Type].position;

        //�������� ����� ��������, �, ���� � ��� ���� ���� ID� �������� ��� ��������
        FieldInfo fi = _rewardList[i].GetType().GetField("ID");
        Enum id = (Enum)fi?.GetValue(_rewardList[i]);

        //�������� ������ ����������� �� ���� �������
        startPosition.z = endPosition.z;

        //��������� ��������, �������������� �������� ���������� ������ � ����� �������� � ��������� ���������� �������� ����, �������� �� ����� ������������,
        //����� ������ �������� ����� �� ������� ��������� �������� � �� ������� �� ��������� ��������� ������.
        reward.StartMoveAnimation(_rewardList[i].Icon, _mainUITransform.InverseTransformPoint(startPosition), _mainUITransform.InverseTransformPoint(endPosition));

        //���������� ���������� ��������, ���� id != null
        if (id != null)
        {
            _addReward[_rewardList[i].Type]?.Invoke(id);
        }
    }

public void  StartGenerateReward(float generateDelay, Vector3 startPosition)
    {
        StartCoroutine(GenerateReward(generateDelay, startPosition));
    }
}
