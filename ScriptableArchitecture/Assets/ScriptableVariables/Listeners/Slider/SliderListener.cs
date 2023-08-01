using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class SliderListener<T> : VariableListener<T>
{
    private Slider sliderField;
    protected override void Awake()
    {
        sliderField = GetComponent<Slider>();
        base.Awake();
    }

    protected override void OnVariableValueChange(T value)
    {
        base.OnVariableValueChange(value);
        UpdateSlider(value);
    }

    private void UpdateSlider(T value)
    {
        float fValue = 0;
        if (float.TryParse($"{value}", out fValue))
            sliderField.value = fValue;
    }
}
