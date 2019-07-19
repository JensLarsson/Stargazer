using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanet
{
    public void CreateNew(List<Texture2D> textures, Vector2 potision)
    {
        float vertical = Camera.main.orthographicSize;
        float horizontal = vertical * Screen.width / Screen.height;
        int textureIndex = Random.Range(0, textures.Count);
        Planet planet = new Planet()
        {
            name = TempLibrary.randomPlanetNames[Random.Range(0, TempLibrary.randomPlanetNames.Count)], //name = Random.Range(0, 9999).ToString(),
            boardPosition = potision,
            textureInt = textureIndex,
            planetScale = Random.Range(4.0f, 10.0f)
        };

        planet.majorityPopString = TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomRaces.Count)];
        int randomSize = Random.Range(1, 4);

        //print(randomSize);
        planet.minorityPopsString = "the " + TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomPlanetNames.Count)];
        for (int i = 1; i < randomSize; i++)
        {
            planet.minorityPopsString += ", the " + TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomPlanetNames.Count)];
        }
        planet.minorityPopsString += " and the " + TempLibrary.randomRaces[Random.Range(0, TempLibrary.randomPlanetNames.Count)];

        
        int locationCount = Random.Range(2, 5);
        for (int i = 0; i < locationCount; i++)
        {
            Location location = new Location();
            planet.locations.Add(location);
        }

        JSONserializer json = new JSONserializer();
        Debug.Log(json.SaveFile(planet)); //Saves planet as a file which returns a string
    }
}
