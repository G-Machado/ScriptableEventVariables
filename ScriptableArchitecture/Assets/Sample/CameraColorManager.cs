using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorManager : MonoBehaviour
{
    [SerializeField] private IntVariable counter;

    private void OnEnable()
    {
        if(counter)
            counter.OnValueChange.AddListener(ChangeCameraColor);
    }

    private void OnDisable()
    {
        if(counter)
            counter.OnValueChange.RemoveListener(ChangeCameraColor);
    }

    public void ChangeCameraColor(int counter)
    {
        Color newColor = new Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            1f
        );

        Camera.main.backgroundColor = newColor;
    }
}
