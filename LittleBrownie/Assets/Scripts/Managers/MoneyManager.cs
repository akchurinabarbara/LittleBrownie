using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoneyManager : ChangeValue<int>
{
    private const int _startValue = 0;

    private DatabaseHandler _databaseHandler;

    public MoneyManager(DatabaseHandler databaseHandler)
    {
        _databaseHandler = databaseHandler;

        var moneyFromDB = _databaseHandler.GetMoney();

        if (moneyFromDB.Count == 0)
        {
            CurrentValue = _startValue;
            _databaseHandler.AddMoney(CommonTypes.MoneyItemID.money1, _startValue);
        }
        else
        {
            CurrentValue = moneyFromDB.Where((Money money) => money.CollectionItemID == (int)CommonTypes.MoneyItemID.money1).First().Count;
        }
    }

    public override void Add(int addValue)
    {
        CurrentValue += addValue;
    }

    public override bool Check()
    {
        return CurrentValue > 0;
    }

    public override void Spend(int spendValue)
    {
        CurrentValue -= spendValue;
    }

    public void Save()
    {
        _databaseHandler.UpdateMoney(CommonTypes.MoneyItemID.money1, CurrentValue);
    }
}
