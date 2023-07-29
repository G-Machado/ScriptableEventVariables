using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "TriggerEvent")]
public class ScriptableEvent : ScriptableObject
{
    [HideInInspector] public UnityEvent<Component> OnEventTrigger;
    public void TriggerEvent(Component sender) { OnEventTrigger.Invoke(sender); }
}
