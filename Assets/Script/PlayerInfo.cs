using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public static class PlayerInfo
{
    public static string name;
    public static Planet currentPlanet;
    //Inventory är en lista av ItemSlots, vilket innehåller en Item, och antalet av items.
    //Inventory har även logik för att hantera dessa objekt
    public static Inventory inventory = new Inventory();
    public static int currency;
    //Håller info om spelarens nuvarande status, vilken planet de befinner sig på, vilka resurser de har, etc.
}
