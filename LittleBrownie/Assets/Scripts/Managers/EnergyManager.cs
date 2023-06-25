using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : ChangeValue<int>
{
    private const int _startValue = 10;

    public EnergyManager()
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
        CurrentValue-= spendValue;
    }
}
