using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField]
    private float _removeTime;

    public Action<Garbage> OnClick;
    public Action<Garbage> OnRemove;    

    private bool _isSelected = false;
    private bool _isDeleted = false;

    public float RemoveTime { get { return _removeTime; } }

    public void ResetSelection()
    {
        _isSelected = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isSelected && !_isDeleted)
        {
            EnergyController energyController = collision.gameObject.GetComponent<EnergyController>();

            if (energyController.CheckEnergy())
            {
                energyController.SpendEnergy();
                OnRemove?.Invoke(this);
                _isDeleted = true;
                Destroy(gameObject, _removeTime);
            }
            else
            {
                ResetSelection();
            }
        }
    }

    private void OnMouseUp()
    {
        _isSelected = true;
        OnClick?.Invoke(this);
    }
}
