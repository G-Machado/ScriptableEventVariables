using System;
using UnityEditor;
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
    { OnValueChange.Invoke(Value); }

    public void OnAfterDeserialize()
    { _runtimeValue = _value; }
}


// Custom Inspector
[CustomEditor(typeof(ScriptableVariable<>), true)]
public class ScriptableVariableEditor : Editor
{
    bool showPosition = false;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //showPosition = 
        //    EditorGUILayout.BeginFoldoutHeaderGroup(showPosition, "Runtime");
        //EditorGUILayout.EndFoldoutHeaderGroup();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Trigger", GUILayout.Height(30), GUILayout.Width(100)))
        {
            Type T = target.GetType().BaseType.DeclaringType;

            Debug.Log($"triggering event {T}");
            target.GetType().GetMethod("Trigger").Invoke(target, null);
        }

        GUILayout.EndHorizontal();
    }
}
