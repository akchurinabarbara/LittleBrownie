using CommonTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//генератор награды
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


        //—лучайно определ€ем награду
        int i = UnityEngine.Random.Range(0, _rewardList.Count);

        Reward reward = Instantiate(_rewardObject, _mainUITransform).GetComponent<Reward>();

        //ќпредел€ем конечную точку и ID предмета по типу
        Vector3 endPosition = _endPoints[(int)_rewardList[i].Type].position;

        //ѕолучить класс предмета, и, если в нем есть поле IDб получить его значение
        FieldInfo fi = _rewardList[i].GetType().GetField("ID");
        Enum id = (Enum)fi?.GetValue(_rewardList[i]);

        //ƒвижение должно происходить на слое канваса
        startPosition.z = endPosition.z;

        //«апускаем анимацию, предварительно перевед€ координаты начала и конца движени€ в локальные координаты главного меню, которому он будет принадлежать,
        //чтобы объект двигалс€ чисто по системе координат родител€ и не зависил от глобаного положени€ камеры.
        reward.StartMoveAnimation(_rewardList[i].Icon, _mainUITransform.InverseTransformPoint(startPosition), _mainUITransform.InverseTransformPoint(endPosition));

        //«аписываем полученное значение, если id != null
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
