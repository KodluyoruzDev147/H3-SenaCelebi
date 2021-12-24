using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingRoller : MonoBehaviour
{
    private bool _isFilled;
    private float _value;

    public void IncrementRollerVolume(float value)
    {
        _value += value;
        
        if (_value > 1)
        {
            float leftValue = value - 1;
            int rollerCount = PlayerController.Current.rollersList.Count;
            transform.localPosition = new Vector3(transform.localPosition.x,-0.5f * (rollerCount - 1) + -0.25f, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f,transform.localScale.y, 0.5f);
            PlayerController.Current.CreateRoller(leftValue);
            
        }
        else if(_value<0)
        {
            PlayerController.Current.DestroyRoller(this);
        }
        else
        {
            //Update the size of roller
            int rollerCount = PlayerController.Current.rollersList.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (rollerCount - 1) + -0.25f * _value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * _value, transform.localScale.y, 0.5f * _value);

        }
    }
}
