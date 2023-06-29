using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : ChangeValue<int>
{
    private const int _startValue = 10;

    private DatabaseHandler _databaseHandler;

    public EnergyManager(DatabaseHandler databaseHandler)
    {
        _databaseHandler = databaseHandler;

        var energyFromDB = _databaseHandler.GetEnergy();

        if (energyFromDB.Count == 0)
        {
            CurrentValue = _startValue;
            _databaseHandler.AddEnergy(_startValue);
        }
        else
        {
            CurrentValue = energyFromDB[0].count;
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
        CurrentValue-= spendValue;
    }

    public void Save()
    {
        _databaseHandler.UpdateEnergy(CurrentValue);
    }
}
