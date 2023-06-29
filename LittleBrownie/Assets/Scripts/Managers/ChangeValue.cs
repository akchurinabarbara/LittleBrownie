using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeValue<T>
{
    private T _currentValue;

    public Action<T> OnValueChange;

    public T CurrentValue
    {
        get { return _currentValue; }
        protected set
        {
            _currentValue = value;
            OnValueChange?.Invoke(value);
        }
    }

    public virtual void Add(T addValue) { }

    public virtual bool Check() { return false; }

    public virtual void Spend(int spendValue) { }
}
