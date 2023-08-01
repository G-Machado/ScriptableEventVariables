using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableVariable<T> : ScriptableObject
{
    [SerializeField] private bool runtimeValue = true;
    [SerializeField] private T _value;
    public T Value
    {
        get { return runtimeValue ? _runtimeValue : _value; }
        set
        {
            if (runtimeValue)
                { _runtimeValue = value; OnValueChange.Invoke(_runtimeValue); }
            else
                { _value = value; OnValueChange.Invoke(_value); }
        }
    }

    [NonSerialized]
    private T _runtimeValue;

    [HideInInspector] public UnityEvent<T> OnValueChange;

    public void Trigger()
    { OnValueChange.Invoke(_value); }

    public void OnAfterDeserialize()
    { _runtimeValue = _value; }
}
