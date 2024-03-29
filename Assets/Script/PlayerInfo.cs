﻿using System.Collections;
using System.Collections.Generic;

//Håller info om spelarens nuvarande status, vilken planet de befinner sig på, vilka resurser de har, etc.
public static class PlayerInfo
{
    public static string name;
    public static Planet currentPlanet;
    //Inventory är en lista av ItemSlots, vilket innehåller en Item, och antalet av items.
    //Inventory har även logik för att hantera dessa objekt
    public static Inventory inventory = new Inventory();
    private static List<int> quests = new List<int>();
    private static int currency = 5000;
    public static int Currency
    {
        get { return currency; }
    }
    public static bool Pay(int cost)
    {
        if (currency - cost < 0)
        {
            return false;
        }
        currency -= cost;
        return true;
    }
    public static bool EndQuest(int ID)
    {
        if (QuestManager.GetQuest(ID) != null)
        {
            GetQuest(ID).completed = true;
            return true;
        }
        return false;
    }


    public static bool StartQuest(int ID)
    {
        if (QuestManager.GetQuest(ID) != null)
        {
            quests.Add(ID);
            return true;
        }
        return false;
    }

    public static Quest GetQuest(int ID)
    {
        if (quests.Contains(ID))
        {
            return QuestManager.GetQuest(ID);
        }
        return null;
    }

    static PlayerInfo()
    {
        inventory.GenerateNewInventory(3);
    }

    //public static void SavePlayer()
    //{

    //}
}

