using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONserializer
{
    //Saves a file for an indivudual plannet
    //
    public string SaveFile(Planet planet)
    {
        var outputString = JsonUtility.ToJson(planet);
        Directory.CreateDirectory(Application.persistentDataPath + "/Planets/Generated");
        string location = Application.persistentDataPath + "/Planets/Generated/" + planet.name + ".txt";
        File.WriteAllText(location, outputString);
        return location;
    }

    public List<Item> LoadItemLibrary()
    {
        List<Item> items;
        try
        {
            string location = Application.persistentDataPath + "/Data/ItemList.txt";
            string s = File.ReadAllText(location); //Loads all the text in the file
            itemLibrary itemLib = JsonUtility.FromJson<itemLibrary>(s); //DeSerializes the string just loaded
            items = itemLib.items;
        }
        catch
        {
            itemLibrary itemLib = new itemLibrary();
            itemLib.CreateLibraryFile();

            string location = Application.persistentDataPath + "/Data/ItemList.txt";
            string s = File.ReadAllText(location); //Loads all the text in the file
            itemLib = JsonUtility.FromJson<itemLibrary>(s); //DeSerializes the string just loaded
            items = itemLib.items;
        }
        return items;
    }

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
        string s = File.ReadAllText(location);
        Character character = JsonUtility.FromJson<Character>(s);
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
        string filePath = Application.persistentDataPath + "/Planets/";
        try
        {
            foreach (string file in Directory.GetFiles(filePath, "*.txt"))
            {
                string s = File.ReadAllText(file);
                Planet saveFile = JsonUtility.FromJson<Planet>(s);
                planets.Add(saveFile);
            }
        }
        catch { Debug.Log("Filepath " + filePath + " Not Found"); }

        filePath += "Generated/";
        try
        {
            foreach (string file in Directory.GetFiles(filePath, "*.txt"))
            {
                string s = File.ReadAllText(file);
                Planet saveFile = JsonUtility.FromJson<Planet>(s);
                planets.Add(saveFile);
            }
        }
        catch { Debug.Log("Filepath " + filePath + " Not Found"); }

        return planets;
    }


    public void DeleteFolder(string s)
    {
        Directory.Delete(s, true);
    }
}
