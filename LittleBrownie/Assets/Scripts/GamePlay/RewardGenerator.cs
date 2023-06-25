using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������� �������
public class RewardGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _rewardObject;

    [SerializeField]
    private List<Item> _rewardList = null;

    [SerializeField]
    private Transform _mainUITransform;

    [SerializeField]
    private List<Transform> _endPoints;


    private Dictionary<ItemType, Action> _addReward = new Dictionary<ItemType, Action>
    {
        [ItemType.money] = () => { AppContext.MoneyManager.Add(1); },
        [ItemType.inventoryItem] = () => { AppContext.MoneyManager.Add(1); },
        [ItemType.collectionItem] = () => { AppContext.MoneyManager.Add(1); }
    };

    private IEnumerator GenerateReward(float generateDelay, Vector3 startPosition)
    {
        yield return new WaitForSeconds(generateDelay);


        //�������� ���������� �������
        int i = UnityEngine.Random.Range(0, _rewardList.Count);

        Reward reward = Instantiate(_rewardObject, _mainUITransform).GetComponent<Reward>();

        //���������� �������� ����� �� ����
        Vector3 endPosition = _endPoints[(int)_rewardList[i].Type].position;

        //�������� ������ ����������� �� ���� �������
        startPosition.z = endPosition.z;

        //��������� ��������, �������������� �������� ���������� ������ � ����� �������� � ��������� ���������� �������� ����, �������� �� ����� ������������,
        //����� ������ �������� ����� �� ������� ��������� �������� � �� ������� �� ��������� ��������� ������.
        reward.StartMoveAnimation(_rewardList[i].Icon, _mainUITransform.InverseTransformPoint(startPosition), _mainUITransform.InverseTransformPoint(endPosition));

        //���������� ���������� ��������
        _addReward[_rewardList[i].Type]?.Invoke();
    }

public void  StartGenerateReward(float generateDelay, Vector3 startPosition)
    {
        StartCoroutine(GenerateReward(generateDelay, startPosition));
    }
}
