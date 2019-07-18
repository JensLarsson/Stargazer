using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TempLibrary
{
    // This is a temporary script holding data that will later be serialized

    public static List<string> randomSectorNames = new List<string>()
    {
        "Milky", "Astern", "Andromeda", "Ultramar", "Gaymer"
    };

    public static List<string> randomPlanetNames = new List<string>()
    {
        "Earth", "Mars", "Jupiter", "Centauri", "Mustafar", "Courcant", "Shire", "Gandalf", "Sheapard", "Gao", "Qubec" // 11
    };

    public static List<string> randomResources = new List<string>()
    {
        "Organics", "Metal", "Fuel", "Energy", "Weapons", "Magic", "Gnomes", "Toys", "Lego", "Computers", "Robots" // 11
    };

    public static List<string> randomRaces = new List<string>()
    {
        "Jews", "Telitubbies", "Nazis", "Definetly not Goblins", "Tau", "Elves", "Eldar", "Legomen", "Emojis", "Cyborgs", "Humanns" // 11
    };
}
