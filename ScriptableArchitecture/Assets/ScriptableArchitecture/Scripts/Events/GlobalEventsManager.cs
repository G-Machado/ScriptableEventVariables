using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor;

public class GlobalEventsManager : Singleton<GlobalEventsManager>
{
    [SerializeField] private EventsTable events;

    public static void AddListener(string eventName, UnityAction<Component> listener)
    {
        EventsTable events = Instance.events;
        ScriptableEvent scriptableEvent = events.GetEvent(eventName);

        if (scriptableEvent != null)
        {
            scriptableEvent.OnEventTrigger.AddListener(listener);
        }
        else
        {
            scriptableEvent = ScriptableObject.CreateInstance<ScriptableEvent>();
            scriptableEvent.name = eventName;

            scriptableEvent.OnEventTrigger = new UnityEvent<Component>();
            scriptableEvent.OnEventTrigger.AddListener(listener);

            events.AddEvent(eventName, scriptableEvent);
        }
    }

    public static void RemoveListener(string eventName, UnityAction<Component> listener)
    {
        EventsTable events = Instance.events;
        ScriptableEvent scriptableEvent = events.GetEvent(eventName);

        if (scriptableEvent != null)
        {
            scriptableEvent.OnEventTrigger.RemoveListener(listener);
        }
        else
        {
            throw new System.Exception($"Can't remove listerner, {eventName} doesn't exist.");
        }
    }

    public static void TriggerEvent(string eventName, Component sender = null)
    {
        EventsTable events = Instance.events;
        ScriptableEvent scriptableEvent = events.GetEvent(eventName);

        if (scriptableEvent != null)
        {
            scriptableEvent.OnEventTrigger.Invoke(sender);
        }
        else
        {
            throw new System.Exception($"Can't trigger event, {eventName} doesn't exist.");
        }
    }

}
