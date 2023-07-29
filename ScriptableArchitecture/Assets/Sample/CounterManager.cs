using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    [SerializeField] private IntVariable variable;
    [SerializeField] private FloatVariable fVariable;
    [SerializeField] private VariableSO counter;

    public void IncreaseCounter()
    {
        variable.Value += 1;
        fVariable.Value += 1;
        counter.Value = (int) counter.Value + 1;

        if (variable.Value % 10 == 0)
        {
            variable.Trigger();
        }
    }
}
