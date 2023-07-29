using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventsTable
{
    [System.Serializable]
    public class GlobalEvent
    { public string name; public ScriptableEvent Event; }

    [SerializeField]
    public List<GlobalEvent> table;

    //
    public ScriptableEvent GetEvent(string eventName)
    {
        for (int i = 0; i < table.Count; i++)
        {
            if (table[i].name.Equals(eventName)) return table[i].Event;
        }

        return null;
    }
    public bool ContainEvent(string eventName)
    {
        for (int i = 0; i < table.Count; i++)
        {
            if (table[i].name.Equals(eventName)) return true;
        }

        return false;
    }

    //
    public void AddEvent(string eventName, ScriptableEvent sEvent)
    {
        GlobalEvent newEvent = new GlobalEvent();
        newEvent.name = eventName;
        newEvent.Event = sEvent;

        table.Add(newEvent);
    }
    public void RemoveEvent(string eventName)
    {
        for (int i = 0; i < table.Count; i++)
        {
            if (table[i].name.Equals(eventName))
            {
                table.RemoveAt(i);
                return;
            }
        }
    }
}
