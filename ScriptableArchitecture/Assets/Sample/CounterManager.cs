using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    [SerializeField] private IntVariable variable;
    [SerializeField] private TriggerVariable colorChangeTrigger;

    public void IncreaseCounter()
    {
        variable.Value += 1;

        if (variable.Value % 10 == 0)
        {
            colorChangeTrigger.Trigger();
        }
    }
}
