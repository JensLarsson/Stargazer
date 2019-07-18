using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONserializer
{

    public string SaveFile(Planet planet)
    {
        var outputString = JsonUtility.ToJson(planet);
        Directory.CreateDirectory(Application.persistentDataPath + "/Planets");
        string location = Application.persistentDataPath + "/Planets/" + planet.name + ".txt";
        File.WriteAllText(location, outputString);
        return location;
    }
    //public string SaveFile(List<Item> items)
    //{
    //    var outputString = JsonUtility.ToJson(items);
    //    string location = Application.persistentDataPath + "/Data/ItemList.txt";
    //    File.WriteAllText(location, outputString);
    //    return location;
    //}

    public string SaveFile(Character character)
    {
        var outputString = JsonUtility.ToJson(character);
        Directory.CreateDirectory(Application.persistentDataPath + "/Characters");
        string location = Application.persistentDataPath + "/Characters/" + character.name + ".txt";
        File.WriteAllText(location, outputString);
        return location;
    }

    public Character LoadCharacter(string name)
    {
        string location = Application.persistentDataPath + "/Characters/" + name + ".txt";
        Character character = JsonUtility.FromJson<Character>(location);
        return character;
    }
    public List<Character> LoadCharacter(List<string> names)
    {
        List<Character> characters = new List<Character>();
        foreach (string name in names)
        {
            string location = Application.persistentDataPath + "/Characters/" + name + ".txt";
            characters.Add(JsonUtility.FromJson<Character>(location));
        }
        return characters;
    }
    public List<Planet> LoadAllPlanets()
    {
        List<Planet> planets = new List<Planet>();
        foreach (string file in Directory.GetFiles(Application.persistentDataPath + "/Planets/", "*.txt"))
        {
            string s = File.ReadAllText(file);
            Planet saveFile = JsonUtility.FromJson<Planet>(s);
            planets.Add(saveFile);
        }
        return planets;
    }

    public void DeleteFolder(string s)
    {
        Directory.Delete(s, true);
    }
}
