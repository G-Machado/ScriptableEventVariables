using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorManager : MonoBehaviour
{
    [SerializeField] private TriggerVariable colorChange;
    [SerializeField] private ColorVariable color;

    private void OnEnable()
    {
        if(colorChange)
            colorChange.OnValueChange.AddListener(ChangeCameraColor);

        if(color)
            color.OnValueChange.AddListener(UpdateCameraColor);
    }

    private void OnDisable()
    {
        if(colorChange)
            colorChange.OnValueChange.RemoveListener(ChangeCameraColor);

        if(color)
            color.OnValueChange.RemoveListener(UpdateCameraColor);
    }

    private void ChangeCameraColor(TriggerVariable.trigger t)
    {
        Color newColor = new Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            1f
        );

        color.Value = newColor;
    }

    public void UpdateCameraColor(Color color)
    {
        Camera.main.backgroundColor = color;
    }
}
