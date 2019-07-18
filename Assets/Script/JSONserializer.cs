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
    public string SaveFile(List<Item> items)
    {
        var outputString = JsonUtility.ToJson(items);
        string location = Application.persistentDataPath + "/Data/ItemList.txt";
        File.WriteAllText(location, outputString);
        return location;
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
