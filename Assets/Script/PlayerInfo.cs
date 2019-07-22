using System.Collections;
using System.Collections.Generic;

//Håller info om spelarens nuvarande status, vilken planet de befinner sig på, vilka resurser de har, etc.
public static class PlayerInfo
{
    public static string name;
    public static Planet currentPlanet;
    //Inventory är en lista av ItemSlots, vilket innehåller en Item, och antalet av items.
    //Inventory har även logik för att hantera dessa objekt
    public static Inventory inventory = new Inventory();
    private static int currency = 5000;
    public static int Currency
    {
        get;
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


    //public static void SavePlayer()
    //{

    //}
}
