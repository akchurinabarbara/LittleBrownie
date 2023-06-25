using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//генератор награды
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


        //Случайно определяем награду
        int i = UnityEngine.Random.Range(0, _rewardList.Count);

        Reward reward = Instantiate(_rewardObject, _mainUITransform).GetComponent<Reward>();

        //Определяем конечную точку по типу
        Vector3 endPosition = _endPoints[(int)_rewardList[i].Type].position;

        //Движение должно происходить на слое канваса
        startPosition.z = endPosition.z;

        //Запускаем анимацию, предварительно переведя координаты начала и конца движения в локальные координаты главного меню, которому он будет принадлежать,
        //чтобы объект двигался чисто по системе координат родителя и не зависил от глобаного положения камеры.
        reward.StartMoveAnimation(_rewardList[i].Icon, _mainUITransform.InverseTransformPoint(startPosition), _mainUITransform.InverseTransformPoint(endPosition));

        //Записываем полученное значение
        _addReward[_rewardList[i].Type]?.Invoke();
    }

public void  StartGenerateReward(float generateDelay, Vector3 startPosition)
    {
        StartCoroutine(GenerateReward(generateDelay, startPosition));
    }
}
