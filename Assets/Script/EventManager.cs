using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct EventParameter
{
    public Planet planetParam;
    public Location locationParam;
    public Character characterParam;
    public ItemSlot itemSlotParam;
    public Item itemParam;
}

public static class EventManager
{
    private static Dictionary<string, Action<EventParameter>> eventDicionary = new Dictionary<string, Action<EventParameter>>();


    public static void Subscribe(string eventName, Action<EventParameter> subscription)
    {
        Action<EventParameter> thisEvent;
        if (eventDicionary.TryGetValue(eventName, out thisEvent))
        {
            //Lägg till eventet på den existerande Actionen
            thisEvent += subscription;
            //Updatera Dictionary
            eventDicionary[eventName] = thisEvent;
        }
        else
        {
            //Skapa event till Dictionary
            thisEvent += subscription;
            eventDicionary.Add(eventName, thisEvent);
        }
    }

    public static void UnSubscribe(string eventName, Action<EventParameter> subscription)
    {
        Action<EventParameter> thisEvent;
        if (eventDicionary.TryGetValue(eventName, out thisEvent))
        {
            //Tar bort eventet på den existerande Actionen
            thisEvent -= subscription;
            //Updatera Dictionary
            eventDicionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(string eventName, EventParameter param)
    {
        Action<EventParameter> thisEvent;
        if (eventDicionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(param);
        }
    }
}
