public class FloatSliderListener : SliderListener<float>
{ 
    public override float GetSliderRatio()
    {
        return variable_current.Value / variable_total.Value;
    }
}
