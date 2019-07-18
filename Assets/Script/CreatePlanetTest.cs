using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlanetTest : MonoBehaviour
{
    public Text text;
    public void CreatePlanet()
    {
        Planet planet = new Planet()
        {
            name = TempLibrary.randomPlanetNames[Random.Range(0, TempLibrary.randomPlanetNames.Count)],        // name = Random.Range(0, 9999).ToString(),
            boardPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f))
        };

        planet.majorityPopString = TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomRaces.Count)];
        int randomSize = Random.Range(1, 4);

        print(randomSize);
        planet.minorityPopsString = "the " + TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomPlanetNames.Count)];
        for (int i = 1; i < randomSize; i++)
        {
            planet.minorityPopsString += ", the " + TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomPlanetNames.Count)];
        }
        planet.minorityPopsString += " and the " + TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomPlanetNames.Count)];

        JSONserializer json = new JSONserializer();
        text.text = json.SaveFile(planet);
        Color colour = text.color;
        colour.a = 3;
        text.color = colour;
    }

    public void DeletePlanets()
    {
        JSONserializer json = new JSONserializer();
        json.DeleteFolder(Application.persistentDataPath + "/Planets");
    }
}
