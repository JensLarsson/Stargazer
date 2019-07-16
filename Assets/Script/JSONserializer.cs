using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONserializer : MonoBehaviour
{

    public void SaveFile(Planet planet)
    {
        var outputString = JsonUtility.ToJson(planet);
        File.WriteAllText(Application.dataPath + "/SaveTests/" + planet.name + ".txt", outputString);
    }

    public List<Planet> LoadAllPlanets()
    {
        List<Planet> planets = new List<Planet>();
        foreach (string file in Directory.GetFiles(Application.dataPath + "/SaveTests/", "*.txt"))
        {
            Debug.Log(file);
            string s = File.ReadAllText(file);
            Debug.Log(s);
            Planet saveFile = JsonUtility.FromJson<Planet>(s);
            planets.Add(saveFile);
        }
        return planets;
    }
}
