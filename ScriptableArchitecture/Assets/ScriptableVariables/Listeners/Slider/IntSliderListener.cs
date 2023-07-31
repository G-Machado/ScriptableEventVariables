public class IntSliderListener : SliderListener<int>
{   
    public override float GetSliderRatio()
    {
        return 
        ((float)variable_current.Value) / ((float)variable_total.Value);
    }
}
