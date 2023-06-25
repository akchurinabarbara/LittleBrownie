using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : ChangeValue<int>
{
    private const int _startValue = 0;

    public MoneyManager()
    {
        CurrentValue = _startValue;
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
}
